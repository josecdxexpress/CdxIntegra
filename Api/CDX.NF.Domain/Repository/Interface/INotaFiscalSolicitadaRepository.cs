using CDX.NF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository.Interface
{
    public interface INotaFiscalSolicitadaRepository
    {
        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        NotaFiscalSolicitada ObterTodos(string numeroNota, string referencia);

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        void ObterPorId();

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        void Inserir(NotaFiscalSolicitada notaFiscalSolicitada);

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        void Alterar();

        /// <summary>
        /// Exclui logicamente uma nota fiscal
        /// </summary>
        void Excluir();

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        Task<int> InserirAsync(NotaFiscalSolicitada notaFiscalSolicitada);
    }
}
