using CDX.NF.Core.Infraestrutura.Services.Tos;

namespace CDX.NF.Domain.Models.To.Filtro
{
    public class UsuarioFiltroTo: PesquisaTo
    {
        public string Nome { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }
    }
}
