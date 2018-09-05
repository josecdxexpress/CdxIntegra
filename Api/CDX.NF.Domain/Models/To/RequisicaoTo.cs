using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Domain.Models.To
{
    public class RequisicaoTo
    {
        public int Referencia { get; set; }

        public string DscServicoWsSoap { get; set; }

        public string NumeroNotaFiscal { get; set; }

        public string DscTipoOperacao { get; set; }

        public string DscPrestador { get; set; }

        public string ValorNota { get; set; }

        public string DscCidade { get; set; }

        public string DscEtapa { get; set; }

        public float? TempoExecucao { get; set; }

        public string DscStatus { get; set; }

        public string Erro { get; set; }

        public string Observacao { get; set; }
    }
}
