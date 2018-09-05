using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository
{
    public class NotaFiscalSolicitadaRepository : INotaFiscalSolicitadaRepository
    { 
        private readonly Contexto _db;

    public NotaFiscalSolicitadaRepository(Contexto context)
    {
        _db = context;
    }

    /// <summary>
    /// Obtem todos por parametro
    /// </summary>
    public NotaFiscalSolicitada ObterTodos(string usuario, string senha)
    {
        var usuarioObj = _db.Usuario
        .Where(p => p.Login == usuario && p.Senha == senha)
        .FirstOrDefaultAsync().Result;

        return null;
    }

    /// <summary>
    /// Obtem todos por id
    /// </summary>
    public void ObterPorId() { }

    /// <summary>
    /// Persiste um objeto
    /// </summary>
    public void Inserir(NotaFiscalSolicitada notaFiscalSolicitada)
    {
       var notaObj = _db.NotaFiscalSolicitada.AddAsync(notaFiscalSolicitada).Result;
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
        /// Persiste um objeto
        /// </summary>
    public async Task<int> InserirAsync(NotaFiscalSolicitada notaFiscalSolicitada)
        {
            var notaObj = await _db.NotaFiscalSolicitada.AddAsync(notaFiscalSolicitada);
            _db.SaveChanges();
            return notaFiscalSolicitada.Id;
        }
    }
}
