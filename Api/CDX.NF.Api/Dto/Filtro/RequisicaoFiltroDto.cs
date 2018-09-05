using CDX.NF.Core.Infraestrutura.Api;

namespace CDX.NF.Api.Dto.Filtro
{
    /// <summary>
    /// Filtro de pesquisa das requisições
    /// </summary>
    public class RequisicaoFiltroDto : PesquisaBase
    {
        public string NumeroNota { get; set; }

        public int? Referencia { get; set; }
    }
}
