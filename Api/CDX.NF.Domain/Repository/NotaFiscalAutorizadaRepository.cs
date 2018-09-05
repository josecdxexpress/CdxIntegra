using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository
{
    public class NotaFiscalAutorizadaRepository : INotaFiscalAutorizadaRepository
    {
        private readonly Contexto _db;

        public NotaFiscalAutorizadaRepository(Contexto context)
        {
            _db = context;
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public NotaFiscalAutorizada ObterTodos(string numeroNota, string referencia)
        {
            NotaFiscalAutorizada notaObj = null;

            if (!string.IsNullOrEmpty(numeroNota))
            {
                notaObj = _db.NotaFiscalAutorizada
                .Where(p => p.Numero == numeroNota)
                .FirstOrDefaultAsync().Result;
            }

            if (!string.IsNullOrEmpty(referencia))
            {
                notaObj = _db.NotaFiscalAutorizada
                .Where(p => p.Referencia == referencia)
                .FirstOrDefaultAsync().Result;
            }

            return notaObj;
        }

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        public void ObterPorId() { }

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        public void Inserir(NotaFiscalAutorizada notaFiscalAutorizada)
        {
            var notaObj = _db.NotaFiscalAutorizada.AddAsync(notaFiscalAutorizada).Result;
            _db.SaveChanges();
        }

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        public void Alterar() { }

        /// <summary>
        /// Exclui logicamente uma nota fiscal
        /// </summary>
        public void Excluir() { }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<NotaFiscalAutorizada> ObterTodosAsync(string numeroNota, string referencia)
        {
            NotaFiscalAutorizada notaObj = null;

            if (!string.IsNullOrEmpty(numeroNota))
            {
                notaObj = await _db.NotaFiscalAutorizada
                .Where(p => p.Numero == numeroNota)
                .FirstOrDefaultAsync();
            }

            if (!string.IsNullOrEmpty(referencia))
            {
                 notaObj = await _db.NotaFiscalAutorizada
                .Where(p => p.Referencia == referencia)
                .FirstOrDefaultAsync();
            }

            return notaObj;
        }

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        public async Task<int> InserirAsync(NotaFiscalAutorizada notaFiscalAutorizada)
        {
            var notaObj = await _db.NotaFiscalAutorizada.AddAsync(notaFiscalAutorizada);
            _db.SaveChanges();

            return notaFiscalAutorizada.Id;
        }
    }
}