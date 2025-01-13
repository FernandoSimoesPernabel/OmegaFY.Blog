using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Repositories.Avaliations;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Repositories;

internal class AvaliationRepository : BaseRepository<PostAvaliations>, IAvaliationRepository
{
    protected override string CollectionName => throw new NotImplementedException();

    public AvaliationRepository(IMongoDatabase database) : base(database) { }

    public Task<PostAvaliations> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}