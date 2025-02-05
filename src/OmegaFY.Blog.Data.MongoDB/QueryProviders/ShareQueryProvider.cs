using MongoDB.Driver;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Data.MongoDB.Models;

namespace OmegaFY.Blog.Data.MongoDB.QueryProviders;

internal class ShareQueryProvider : IShareQueryProvider
{
    private readonly IMongoCollection<PostCollectionModel> _postCollection;

    private readonly IMongoCollection<UserCollectionModel> _userCollection;

    public ShareQueryProvider(IMongoDatabase database)
    {
        _postCollection = database.GetCollection<PostCollectionModel>(MongoDbContants.POST_COLLECTION);
        _userCollection = database.GetCollection<UserCollectionModel>(MongoDbContants.USER_COLLECTION);
    }

    public async Task<CurrentUserHasSharedPostQueryResult> CurrentUserHasSharedPostQueryResultAsync(Guid postId, Guid authorId, CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.Where(post => post.Id == postId);

        ProjectionDefinition<PostCollectionModel, SharedCollectionModel> projection =
            Builders<PostCollectionModel>.Projection.Expression(post => post.Shareds.Where(shared => shared.AuthorId == authorId).FirstOrDefault());

        SharedCollectionModel shareFromUser = await _postCollection.Find(filter).Project(projection).FirstOrDefaultAsync(cancellationToken);

        return new CurrentUserHasSharedPostQueryResult(postId, shareFromUser?.Id);
    }

    public async Task<PagedResult<GetMostRecentSharesQueryResult>> GetMostRecentSharesQueryResultAsync(
        GetMostRecentSharesQuery request, CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.Where(post => !post.Private);

        if (request.AuthorId.HasValue)
            filter &= Builders<PostCollectionModel>.Filter.ElemMatch(post => post.Shareds, share => share.AuthorId == request.AuthorId.Value);

        long totalOfItems = await _postCollection.AggregateCountAsync(filter, post => post.Shareds, cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItems);

        ProjectionDefinition<PostCollectionModel, GetMostRecentSharesQueryResult[]> projection =
            Builders<PostCollectionModel>.Projection.Expression(post => post.Shareds.Select(share => new GetMostRecentSharesQueryResult()
            {
                ShareId = share.Id,
                ShareAuthorId = share.AuthorId,
                PostId = share.Id,
                PostAuthorId = post.AuthorId,
                DateAndTimeOfShare = share.DateAndTimeOfShare,
                PostTitle = post.Title
            }).OrderByDescending(share => share.DateAndTimeOfShare).ToArray());

        GetMostRecentSharesQueryResult[] result = await _postCollection.Find(filter).Project(projection).FirstOrDefaultAsync(cancellationToken);

        await _userCollection.HydrateAuthorNamesAsync(
            result,
            result =>
            {
                return result.Select(query => query.PostAuthorId).Concat(result.Select(query => query.ShareAuthorId)).ToArray();
            },
            (result, users) => Array.ForEach(result, query =>
            {
                UserCollectionModel postAuthor = users.First(user => user.Id == query.PostAuthorId);
                UserCollectionModel shareAuthor = users.First(user => user.Id == query.ShareAuthorId);

                query.PostAuthorName = postAuthor.DisplayName;
                query.ShareAuthorName = shareAuthor.DisplayName;
            }),
            cancellationToken);

        return new PagedResult<GetMostRecentSharesQueryResult>(pagedResultInfo, result);
    }
}