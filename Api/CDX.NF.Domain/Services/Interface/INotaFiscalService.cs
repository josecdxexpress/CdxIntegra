using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Services.Interface
{
    public interface INotaFiscalService
    {
        Task<Retorno<RetornoServicoTo>> AutorizarAsync(AutorizacaoNfeTo autorizacaoNfeTo);

        Task<Retorno<NotaFiscalRetornoTo>> ConsultarAsync(ConsultaNfeTo notaFiscalTo);

        Task<Retorno<RetornoServicoTo>> CancelarAsync(CancelamentoNfeTo cancelamentoNfeTo);
    }
}
