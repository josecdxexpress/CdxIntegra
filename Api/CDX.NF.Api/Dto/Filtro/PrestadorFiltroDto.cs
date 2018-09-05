using CDX.NF.Core.Infraestrutura.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Dto.Filtro
{
    public class PrestadorFiltroDto: PesquisaBase
    {
        public string Nome { get; set; }

        public string Cnpj { get; set; }
    }
}
