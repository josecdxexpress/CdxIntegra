using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Core.Infraestrutura.Persistence;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDX.NF.Domain.Models
{
    [Table("Usuario")]
    public class Usuario : BaseEntidade
    {
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(10)]
        public string Login { get; set; }

        [Required]
        [MaxLength(10)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        public virtual List<Cidade> Cidades { get; set; } = new List<Cidade>();

        public SituacaoEnum Situacao { get; set; }

}
}