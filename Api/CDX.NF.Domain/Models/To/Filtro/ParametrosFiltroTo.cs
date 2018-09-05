using CDX.NF.Core.Infraestrutura.Services.Tos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Domain.Models.To.Filtro
{
    public class ParametrosFiltroTo : PesquisaTo
    {
        public int? CidadeId { get; set; }

        public int? UsuarioId { get; set; }
    }
}

