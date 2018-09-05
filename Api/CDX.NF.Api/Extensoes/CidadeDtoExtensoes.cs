using CDX.NF.Api.Dto;
using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Extensoes
{
    public static class CidadeDtoExtensoes
    {
        internal static Cidade ToEntity(this CidadeDto re)
        {
            return new Cidade()
            {
                Descricao = re.Descricao,
                Situacao = (SituacaoEnum)Convert.ToInt32(re.Situacao)
            };
        }


        internal static CidadeTo ToTransferObject(this CidadeDto re)
        {
            return new CidadeTo()
            {
                Id = re.Id,
                Descricao = re.Descricao,
                Situacao = re.Situacao
            };
        }
    }
}
