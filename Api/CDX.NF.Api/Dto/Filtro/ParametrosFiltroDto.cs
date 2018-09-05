using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Core.Infraestrutura.Services.Tos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Dto.Filtro
{
    public class ParametrosFiltroDto : PesquisaBase
    {
        public int? CidadeId { get; set; }

        public int? UsuarioId { get; set; }
    }
}
