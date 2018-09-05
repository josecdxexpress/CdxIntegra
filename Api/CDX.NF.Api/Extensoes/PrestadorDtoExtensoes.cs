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
    public static class PrestadorDtoExtensoes
    {
        internal static Prestador ToEntity(this PrestadorDto re)
        {
            return new Prestador()
            {
                Cnpj = re.Cnpj,
                Situacao = (SituacaoEnum)Convert.ToInt32(re.Situacao)
            };
        }


        internal static PrestadorTo ToTransferObject(this PrestadorDto re)
        {
            return new PrestadorTo()
            {
                Id = re.Id,
                Cnpj = re.Cnpj,
                Situacao = re.Situacao
            };
        }
    }
}
