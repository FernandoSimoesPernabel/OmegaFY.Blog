using OmegaFY.Blog.Common.Enums;

namespace OmegaFY.Blog.WebAPI.Configuration.Options
{

    public class DatabaseConfigurationOptions
    {

        public DatabaseStrategy DatabaseStrategy { get; set; }

        public DatabaseAccessObjectStrategy DatabaseAccessObjectStrategy { get; set; }

        public string DatabaseName { get; set; }

    }

}
