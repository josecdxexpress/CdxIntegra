namespace TcpCadastro.Api.Dto
{
    using CDX.NF.Domain.Models.Enum;

    /// <summary>
    /// Classe utilizada para controle de login de usuarios
    /// </summary>
	public class LoginDataDto
	{
		public TipoAutenticacao TipoAutenticacao { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string Token { get; set; }

		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		public string Scope { get; set; }

		public string RefreshToken { get; set; }
	}
}