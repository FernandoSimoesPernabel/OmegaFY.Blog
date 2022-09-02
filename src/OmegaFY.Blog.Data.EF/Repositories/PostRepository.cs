using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Repositories.Posts;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(PostsContext postsContext) : base(postsContext) { }

    public async Task CreatePostAsync(Post post, CancellationToken cancellationToken) => await _dbSet.AddAsync(post, cancellationToken);

    public async Task<Post> GetByIdAsync(Guid id, Guid authorId, CancellationToken cancellationToken)
        => await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Author.Id == authorId, cancellationToken);
}