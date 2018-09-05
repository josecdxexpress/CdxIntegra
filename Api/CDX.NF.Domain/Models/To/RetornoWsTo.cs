using CDX.NF.Domain.Models.Enum;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;

namespace CDX.NF.Domain.Models
{
    public class RetornoWsTo
    {
        public NotaFiscalAutorizadaTo DeserializedNfe { get; set; }

        public RetornoServicoTo RetornoServicoTo { get; set; }

        public EtapaRequisicao Etapa { get; set; }

        public int? TempoExecucao { get; set; }

        public string Observacao { get; set; }
    }
}
