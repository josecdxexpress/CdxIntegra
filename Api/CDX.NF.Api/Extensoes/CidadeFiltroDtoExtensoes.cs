using CDX.NF.Api.Dto.Filtro;
using CDX.NF.Domain.Models.To.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Extensoes
{
    public static class CidadeFiltroDtoExtensoes
    {
        internal static CidadeFiltroTo ToTransferObject(this CidadeFiltroDto dto)
        {
            return new CidadeFiltroTo
            {
                Nome = dto.Nome,

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
