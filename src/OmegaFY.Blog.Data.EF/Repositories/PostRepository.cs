using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Repositories.Posts;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal sealed class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(PostsContext postsContext) : base(postsContext) { }

    public void AddPost(Post post) => _dbSet.Add(post);

    public Task<Post> GetByIdAsync(ReferenceId id, ReferenceId authorId, CancellationToken cancellationToken)
        => _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.AuthorId == authorId, cancellationToken);
}