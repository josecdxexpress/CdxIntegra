using CDX.NF.Core.Infraestrutura.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CDX.NF.Domain.Models
{
    [Table("ServicoWsSoap")]
    public class ServicoWsSoap: BaseEntidade
    {
        [Required]
        [MaxLength(10)]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(60)]
        public string Url { get; set; }

        [MaxLength(60)]
        public string Namespace { get; set; }
    }
}
