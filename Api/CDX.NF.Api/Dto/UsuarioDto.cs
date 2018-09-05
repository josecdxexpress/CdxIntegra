using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Domain.Models;

namespace CDX.NF.Api.Dto
{
    /// <summary>
    /// Informações sobre os usuários.
    /// </summary>
    public class UsuarioDto
    {
        public UsuarioDto()
        {
        }

        public UsuarioDto(Usuario usuario)
        {
            if (usuario == null)
            {
                return;
            }


            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;
            Login = usuario.Login;
            Senha = usuario.Senha;
            Situacao = usuario.Situacao.Equals(SituacaoEnum.Ativo) ? "Ativo" : "Inativo";
        }

        public int? Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public string Situacao { get; set; }
    }
}
