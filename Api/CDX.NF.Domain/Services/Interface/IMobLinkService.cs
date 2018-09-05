using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Services.Interface
{
    public interface IMobLinkService 
    {        
        /* Async */
        Task<Retorno<RetornoWsTo>> AutorizarAsync(WsMobLinkService.CapaAutorizacaoNfse objAutorizar);

        Task<Retorno<RetornoWsTo>> ConsultarAsync(WsMobLinkService.Consultar objConsultar);

        Task<Retorno<RetornoWsTo>> CancelarAsync(WsMobLinkService.Cancelar objCancelar);
    }
}
