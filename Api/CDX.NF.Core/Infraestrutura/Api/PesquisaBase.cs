using CDX.NF.Core.Infraestrutura.Services.Tos;

namespace CDX.NF.Core.Infraestrutura.Api
{
    public class PesquisaBase
    {
        public PesquisaBase()
        {
            IncluirObsoletos = false;
        }

        public bool IncluirObsoletos { get; set; }

        public int? PaginaAtual { get; set; }

        public int? TamanhoPagina { get; set; }

        public int TotalRegistros { get; set; }

        public string Ordenacao { get; set; }

        public SentidoOrdenacao SentidoOrdenacao { get; set; }

        public virtual PesquisaTo ObterPesquisa()
        {
            return ObterPesquisa<PesquisaTo>();
        }

        public virtual T ObterPesquisa<T>() where T : PesquisaTo, new()
        {
            if (!PaginaAtual.HasValue && SentidoOrdenacao == SentidoOrdenacao.Indefinido)
            {
                return null;
            }

            return new T
            {
                IncluirObsoletos = IncluirObsoletos,
                SentidoOrdenacao = SentidoOrdenacao,
                Ordenacao = Ordenacao,
                PaginaAtual = PaginaAtual,
                TamanhoPagina = TamanhoPagina,
                TotalRegistros = TotalRegistros
            };
        }
    }
}