using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Domain.Repositories;

namespace OmegaFY.Blog.Data.EF.UoW;

internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _applicationContext;

    public UnitOfWork(ApplicationContext applicationContext) => _applicationContext = applicationContext;

    public async Task SaveChangesAsync() => await _applicationContext.SaveChangesAsync();
}
