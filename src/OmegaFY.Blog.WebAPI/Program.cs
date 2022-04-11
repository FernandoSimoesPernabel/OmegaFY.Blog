using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AvaliationsContext>(options => options.UseSqlite("Data Source=blog.db"));
builder.Services.AddDbContext<CommentsContext>(options => options.UseSqlite("Data Source=blog.db"));
builder.Services.AddDbContext<DonationsContext>(options => options.UseSqlite("Data Source=blog.db"));
builder.Services.AddDbContext<PostsContext>(options => options.UseSqlite("Data Source=blog.db"));
builder.Services.AddDbContext<SharesContext>(options => options.UseSqlite("Data Source=blog.db"));
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlite("Data Source=blog.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();