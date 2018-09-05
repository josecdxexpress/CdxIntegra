using CDX.NF.Api.Dto.Filtro;
using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models.To.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Extensoes
{
    public static class RequisicaoFiltroDtoExtensoes
    {
        internal static RequisicaoFiltroTo ToTrasferObject(this RequisicaoFiltroDto dto)
        {
            return new RequisicaoFiltroTo
            {
                NumeroNota = dto.NumeroNota,
                Referencia = dto.Referencia,

                IncluirObsoletos = dto.IncluirObsoletos,
                PaginaAtual = dto.PaginaAtual,
                TamanhoPagina = dto.TamanhoPagina,
                TotalRegistros = dto.TotalRegistros,
                Ordenacao = dto.Ordenacao,
                SentidoOrdenacao = dto.SentidoOrdenacao
            };
        }
    }
}
