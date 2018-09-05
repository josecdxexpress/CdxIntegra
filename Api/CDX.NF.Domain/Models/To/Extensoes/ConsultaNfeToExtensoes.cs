using CDX.NF.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Domain.Models.To.Extensoes
{
    public static class ConsultaNfeToExtensoes
    {
        internal static WsMobLinkService.Consultar ToWsConsultarService(this ConsultaNfeTo re, WsSoapServices wsSoapServices)
        {
            if (wsSoapServices == WsSoapServices.MobLink)
            {
                return new WsMobLinkService.Consultar()
                {
                    homologacao = false,
                    cnpj_prestador = re.CnpjPrestador,
                    referencia = re.Referencia
                };
            }

            return null;
        }
    }
}
