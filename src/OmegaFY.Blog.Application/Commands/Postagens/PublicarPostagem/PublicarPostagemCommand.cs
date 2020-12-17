using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Postagens.PublicarPostagem
{

    public class PublicarPostagemCommand : CommandMediatRBase<PublicarPostagemCommandResult>
    {

        public string Titulo { get; set; }

        public string SubTitulo { get; set; }

        public string ConteudoPostagem { get; set; }

    }

}
