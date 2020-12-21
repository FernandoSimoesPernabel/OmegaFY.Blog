using AutoMapper;

namespace OmegaFY.Blog.Infra.Configuration
{

    public class AutoMapperQueriesProfileConfig : Profile
    {

        public AutoMapperQueriesProfileConfig()
        {
            //            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            //.ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }

    }

}
