using CDX.NF.Core.Infraestrutura.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Domain.Services
{
    public interface IXDbxService : ICdxEntityService<Livro, int>
    {
        IList<Livro> Obter(string param);
    }
}
