namespace CDX.NF.Core.Infraestrutura.Services.Tos
{
    public class PesquisaTo
    {
        public PesquisaTo()
        {
            IncluirObsoletos = false;
        }

        public bool IncluirObsoletos { get; set; }

        public int? PaginaAtual { get; set; }

        public int? TamanhoPagina { get; set; }

        public int TotalRegistros { get; set; }

        public string Ordenacao { get; set; }

        public SentidoOrdenacao SentidoOrdenacao { get; set; }
    }
}
