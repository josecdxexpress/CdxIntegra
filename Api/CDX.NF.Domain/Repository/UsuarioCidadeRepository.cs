using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Repository.Interface;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository
{
    public class UsuarioCidadeRepository : IUsuarioCidadeRepository
    {
        private readonly Contexto _db;

        public UsuarioCidadeRepository(Contexto context)
        {
            _db = context;
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public void ObterTodos()
        {
        }

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        public void ObterPorId() { }

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        public void Inserir() { }

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        public void Alterar() { }

        /// <summary>
        /// Exclui logicamente uma nota fiscal
        /// </summary>
        public void Excluir() { }

      }
}
