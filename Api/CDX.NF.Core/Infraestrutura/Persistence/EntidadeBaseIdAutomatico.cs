using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Core.Infraestrutura.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace CDX.NF.Core.Infraestrutura.Persistence
{
    public abstract class BaseEntidade : IEntidade
    {
        [Key]
        public int Id { get; set; }

        public int? UsuarioId { get; set; }

        public DateTime? DataCadastro { get; set; } = DateTime.UtcNow;

        public DateTime? DataAlteracao { get; set; }

        public SituacaoEnum Situacao { get; set; } = SituacaoEnum.Ativo;
    }
}
