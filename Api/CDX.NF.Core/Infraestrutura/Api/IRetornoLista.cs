using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Core.Infraestrutura.Api
{
    public interface IRetornoLista
    {
        object[] ObterDados();
        string ObterDescricao();
        List<Parametro> ObterParametros();
    }
}
