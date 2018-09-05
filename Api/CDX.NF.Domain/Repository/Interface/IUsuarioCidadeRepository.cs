using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Domain.Repository.Interface
{
    /// <summary>
    /// Interface de repository para operações com a entidade nota fiscal.
    /// </summary>
    public interface IUsuarioCidadeRepository
    {
        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        void ObterTodos();

        /// <summary>
        /// Obtem todos por id
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

