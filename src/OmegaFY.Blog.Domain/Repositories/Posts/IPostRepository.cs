﻿using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Domain.Repositories.Posts;

public interface IPostRepository : IRepository<Post>
{
    public void AddPost(Post post);

    public Task<Post> GetByIdAsync(ReferenceId id, ReferenceId authorId, CancellationToken cancellationToken);
}