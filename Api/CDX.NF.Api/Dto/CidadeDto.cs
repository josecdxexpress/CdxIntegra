using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Dto
{
    public class CidadeDto
    {

        public CidadeDto(Cidade cidade)
        {
            if (cidade == null)
            {
                return;
            }


            Id = cidade.Id;
            Descricao = cidade.Descricao;
            Situacao = cidade.Situacao.Equals(SituacaoEnum.Ativo) ? "Ativo" : "Inativo";
        }

        public int? Id { get; set; }

        public string Descricao { get; set; }

        public string Situacao { get; set; }
    }
}
