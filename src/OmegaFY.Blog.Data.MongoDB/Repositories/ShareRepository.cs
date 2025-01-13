using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Repositories.Shares;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Repositories;

internal sealed class ShareRepository : BaseRepository<PostShares>, IShareRepository
{
    protected override string CollectionName => throw new NotImplementedException();

    public ShareRepository(IMongoDatabase database) : base(database) { }

    public Task<PostShares> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}