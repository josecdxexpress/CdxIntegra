using CDX.NF.Core.Infraestrutura.Persistence;
using CDX.NF.Domain.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDX.NF.Domain.Models
{
    [Table("Parametros")]
    public class Parametros : BaseEntidade
    {
        public int CidadeId { get; set; }

        public Cidade Cidade { get; set; }

        public int PrestadorId { get; set; }

        public Prestador Prestador { get; set; }

        public int? ServicoWsSoapId { get; set; }

        public ServicoWsSoap ServicoWsSoap { get; set; }

        public float Alicota { get; set; }

        public string Certificado { get; set; }

        public bool UtilizaCertificado { get; set; }

        public bool BloqueioEmissao { get; set; }
    }
}