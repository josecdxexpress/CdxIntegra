using CDX.NF.Api.Dto.Filtro;
using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models.To.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Extensoes
{
    public static class UsuarioFiltroDtoExtensoes
    {
        internal static UsuarioFiltroTo ToTransferObject(this UsuarioFiltroDto dto)
        {
            return new UsuarioFiltroTo
            {
                Nome = dto.Nome,
                Login = dto.Login,
                Email = dto.Email,

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
