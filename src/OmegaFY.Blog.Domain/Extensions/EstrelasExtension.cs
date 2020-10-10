using OmegaFY.Blog.Domain.Core.Enums;
using System.ComponentModel;

namespace OmegaFY.Blog.Domain.Extensions
{

    public static class EstrelasExtension
    {

        public static float NotaDaAvaliacao(this Estrelas estrela) 
            => (float)estrela.GetAttributeOfType<DefaultValueAttribute>().Value;

    }

}
