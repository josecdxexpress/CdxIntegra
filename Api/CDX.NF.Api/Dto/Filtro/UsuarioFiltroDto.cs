using CDX.NF.Core.Infraestrutura.Api;

namespace CDX.NF.Api.Dto.Filtro
{
    /// <summary>
    /// Filtro de pesquisa dos usuarios
    /// </summary>
    public class UsuarioFiltroDto : PesquisaBase
    {
        public string Nome;

        public string Login;

        public string Email;
    }
}
