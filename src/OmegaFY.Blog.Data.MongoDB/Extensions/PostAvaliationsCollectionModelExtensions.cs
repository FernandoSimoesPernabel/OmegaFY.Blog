using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Avaliations;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class PostAvaliationsCollectionModelExtensions
{
    public static PostAvaliations ToPostAvaliations(this PostAvaliationsCollectionModel postModel) 
        => PostAvaliations.Create(postModel.Id, postModel.Avaliations.ToArrayOfAvaliation(), postModel.AverageRate);
}