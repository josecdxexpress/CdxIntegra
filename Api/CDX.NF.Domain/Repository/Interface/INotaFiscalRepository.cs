using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models.To;

namespace CDX.NF.Domain.Repository.Interface
{
    /// <summary>
    /// Interface de repository para operações com a entidade nota fiscal.
    /// </summary>
    public interface INotaFiscalRepository
    {
        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Retorno<NotaFiscalRetornoTo> ObterTodos(PesquisaNotaFiscalTo pesquisaTo);

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        void ObterPorId();

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        void Inserir();

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        void Alterar();

        /// <summary>
        /// Exclui logicamente uma nota fiscal
        /// </summary>
        void Excluir();
    }
}
