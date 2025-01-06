using Microsoft.EntityFrameworkCore;

namespace OmegaFY.Blog.Data.EF.Context;

internal class SqlServerQueryContext : QueryContext
{
    public SqlServerQueryContext(DbContextOptions<QueryContext> options) : base(options) { }
}