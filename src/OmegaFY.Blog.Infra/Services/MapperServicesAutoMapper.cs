using AutoMapper;
using OmegaFY.Blog.Domain.Core.Services;

namespace OmegaFY.Blog.Infra.Services
{

    internal class MapperServicesAutoMapper : IMapperServices
    {

        private readonly IMapper _mapper;

        public MapperServicesAutoMapper(IMapper mapper) => _mapper = mapper;

        public TOut MapToObject<TIn, TOut>(TIn obj)
            where TIn : class
            where TOut : class
        {
            return _mapper.Map<TOut>(obj);
        }

    }

}
