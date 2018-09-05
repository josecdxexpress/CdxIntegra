using CDX.NF.Domain.Models.Enum;

namespace CDX.NF.Domain.Models.To.Extensoes
{
    public static class CancelamentoNfeToExtensoes
    {
        internal static WsMobLinkService.Cancelar ToWsCancelarService(this CancelamentoNfeTo re, WsSoapServices wsSoapServices)
        {
            if (wsSoapServices == WsSoapServices.MobLink)
            {
                return new WsMobLinkService.Cancelar()
                {
                    homologacao = false,
                    justificativa = re.Justificativa,
                    referencia = re.Referencia
                };
            }

            return null;
        }
    }
}