using CDX.NF.Core.Infraestrutura.Persistence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDX.NF.Domain.Models
{
    [Table("Cidade")]
    public class Cidade : BaseEntidade
    {
        [Required]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(60)]
        public string Descricao { get; set; }
    }
}
