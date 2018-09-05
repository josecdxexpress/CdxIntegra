namespace TcpCadastro.Api.Dto
{
    using CDX.NF.Api.Dto;
    using CDX.NF.Domain.Models;
    using CDX.NF.Domain.Models.Enum;
    using System;

	public class LoginDto
	{
		public LoginDto()
		{
		}

		public LoginDto(Login elemento, Usuario usuario = null)
		{
			if (elemento == null)
			{
				return;
			}

			//Id = elemento.Id;
			//LoginAcesso = elemento.LoginAcesso;
			//UltimoLogin = elemento.UltimoLogin;
			//TipoAutenticacao = elemento.TipoAutenticacao;

			if (usuario != null)
			{
				//Usuario = new UsuarioDto(elemento.Usuario);
			}
		}

		public TipoAutenticacao TipoAutenticacao { get; set; }

		public DateTime? UltimoLogin { get; set; }

		public int Id { get; set; }

		public UsuarioDto Usuario { get; set; }

		public string LoginAcesso { get; set; }
	}
}