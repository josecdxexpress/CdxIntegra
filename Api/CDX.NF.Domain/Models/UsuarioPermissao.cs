using CDX.NF.Core.Infraestrutura.Persistence;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDX.NF.Domain.Models
{
    [Table("UsuarioPermissao")]
    public class UsuarioPermissao: BaseEntidade
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        public int? PrestadorId { get; set; }
        public Prestador Prestador { get; set; }

        public bool BloqueioEmissao { get; set; }
    }
}