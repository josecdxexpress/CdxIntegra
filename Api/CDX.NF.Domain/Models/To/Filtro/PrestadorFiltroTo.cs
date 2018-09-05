using CDX.NF.Core.Infraestrutura.Services.Tos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Domain.Models.To.Filtro
{
    public class PrestadorFiltroTo : PesquisaTo
    {
        public string Cnpj { get; set; }

        public string Nome { get; set; }
    }
}
