using CDX.NF.Core.Infraestrutura.Persistence;
using CDX.NF.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CDX.NF.Domain.Models
{
    [Table("Requisicao")]
    public class Requisicao : BaseEntidade
    {
        [Required]
        [MaxLength(50)]
        public int Referencia { get; set; }

        public int? ServicoWsSoapId { get; set; }
        public ServicoWsSoap ServicoWsSoap { get; set; }

        public int? NotaFiscalAutorizadaId { get; set; }
        public NotaFiscalAutorizada NotaFiscalAutorizada { get; set; }

        public TipoOperacao TipoOperacao { get; set; }

        public int? PrestadorId { get; set; }
        public Prestador Prestador { get; set; }

        public string ValorNota { get; set; }

        public int? CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        public EtapaRequisicao Etapa { get; set; }

        public float? TempoExecucao { get; set; }

        public StatusOperacao Status { get; set; }

        public string Erro { get; set; }

        public string Observacao { get; set; }

    }
}