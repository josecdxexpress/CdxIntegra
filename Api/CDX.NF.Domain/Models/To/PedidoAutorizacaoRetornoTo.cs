using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Domain.Models.To
{
    public class PedidoAutorizacaoRetornoTo
    {
        public string PrestadorCnpj { get; set; }

        public string Referencia { get; set; }

        public string Status { get; set; }
    }
}
