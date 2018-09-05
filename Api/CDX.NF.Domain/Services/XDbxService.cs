using CDX.NF.Core.Infraestrutura.Persistence;
using CDX.NF.Core.Infraestrutura.Services;
using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CDX.NF.Domain.Services
{
    public class XDbxService : CdxEntityService<Livro, int>, IXDbxService
    {
        private readonly Contexto _db;

        public XDbxService(Contexto context)
        {
            _db = context;
        }

        public IList<Livro> Obter(string param)
        {
            IRepository<Usuario, int> genericRepository = new GenericRepository<Usuario, int>(_db);

            var teste = genericRepository.ObterPorId(1);

            var lista = Repository.ObterTodos();
            return null;
        }
    }
}
