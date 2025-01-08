using Microsoft.EntityFrameworkCore;

namespace OmegaFY.Blog.Data.EF.Context;

internal class SqliteQueryContext : QueryContext
{
    public SqliteQueryContext(DbContextOptions<QueryContext> options) : base(options) { }
}