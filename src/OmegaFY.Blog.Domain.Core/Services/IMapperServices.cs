namespace OmegaFY.Blog.Domain.Core.Services
{

    public interface IMapperServices
    {
        public TOut MapToObject<TIn, TOut>(TIn obj) where TIn : class where TOut : class;
    }

}
