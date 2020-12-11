using AutoMapper;

namespace OmegaFY.Blog.Infra.Configuration
{

    public class AutoMapperProfileConfig : Profile
    {

        public AutoMapperProfileConfig()
        {
            //            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            //.ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }

    }

}
