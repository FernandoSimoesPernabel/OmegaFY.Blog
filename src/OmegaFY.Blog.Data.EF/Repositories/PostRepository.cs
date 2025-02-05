using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Repositories.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal sealed class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(PostsContext postsContext) : base(postsContext) { }

    public Task AddPostAsync(Post post, CancellationToken cancellationToken)
    {
        _dbSet.Add(post);
        return Task.CompletedTask;
    }

    public Task UpdatePostAsync(Post post, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<Post> GetByIdAsync(ReferenceId postId, ReferenceId authorId, CancellationToken cancellationToken)
        => _dbSet.FirstOrDefaultAsync(post => post.Id == postId && post.AuthorId == authorId, cancellationToken);
}