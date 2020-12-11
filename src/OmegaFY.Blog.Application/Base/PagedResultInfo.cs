namespace OmegaFY.Blog.Application.Base
{

    public class PagedResultInfo
    {

        public int PaginaAtual { get; private set; }

        public int TotalDePaginas { get; private set; }

        public int QuantidadeItensNaPagina { get; private set; }

        public int TotalDeItens { get; private set; }

        public bool TemProximaPagina => PaginaAtual < TotalDePaginas;

        public bool TemPaginaAnterior => PaginaAtual > 1;

        public PagedResultInfo(int paginaAtual, int totalDePaginas, int quantidadeItensNaPagina, int totalDeItens)
        {
            PaginaAtual = paginaAtual;
            TotalDePaginas = totalDePaginas;
            QuantidadeItensNaPagina = quantidadeItensNaPagina;
            TotalDeItens = totalDeItens;
        }

    }

}
