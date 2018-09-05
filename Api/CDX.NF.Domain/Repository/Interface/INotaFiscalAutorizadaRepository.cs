using CDX.NF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository.Interface
{
    /// <summary>
    /// Interface de repository para operações com a entidade nota fiscal.
    /// </summary>
    public interface INotaFiscalAutorizadaRepository
    {
        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        NotaFiscalAutorizada ObterTodos(string numeroNota, string referencia);

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        void ObterPorId();

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        void Inserir(NotaFiscalAutorizada notaFiscalAutorizada);

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        void Alterar();

        /// <summary>
        /// Exclui logicamente uma nota fiscal
        /// </summary>
        void Excluir();

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<NotaFiscalAutorizada> ObterTodosAsync(string numeroNota, string referencia);

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        Task<int> InserirAsync(NotaFiscalAutorizada notaFiscalAutorizada);
    }
}
