using CDX.NF.Api.Dto;
using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models.To;

namespace CDX.NF.Api.Extensoes
{
    public static class PesquisaToExtensoes
    {
        internal static PesquisaTo ToTransferObject(this PesquisaDto re)
        {
            return new PesquisaTo()
            {
                //Numero = re.Numero,
                //FormaRetorno = re.FormaRetorno
            };
        }
    }
}
