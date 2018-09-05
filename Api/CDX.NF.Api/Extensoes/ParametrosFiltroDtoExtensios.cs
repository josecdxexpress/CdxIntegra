using CDX.NF.Api.Dto.Filtro;
using CDX.NF.Domain.Models.To.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Extensoes
{
    public static class ParametrosFiltroDtoExtensios
    {
        internal static ParametrosFiltroTo ToTrasferObject(this ParametrosFiltroDto dto)
        {
            return new ParametrosFiltroTo
            {
                CidadeId = dto.CidadeId,
                UsuarioId = dto.UsuarioId,

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
