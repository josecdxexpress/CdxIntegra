using CDX.NF.Core.Infraestrutura.Api;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TcpCadastro.Api.Dto;
using Microsoft.AspNetCore.Authorization;

namespace CDX.NF.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AutenticacaoController: Controller
    {
        public async Task<OkObjectResult> Post(LoginDataDto dados)
        {
            var resultado = new Retorno<LoginDataDto>();

            string identityServer;

            //if (dados.TipoAutenticacao == TipoAutenticacao.Indefinido)
            //{
            //    List<Login> login = _loginEntityService.ObterPorLogin(dados.Username);

            //    if (login.Count == 1)
            //    {
            //        dados.TipoAutenticacao = login[0].TipoAutenticacao;
            //    }
            //    else
            //    {
            //        resultado.AdicionarMensagem("CAD-010");
            //        resultado.Status = ResultadoOperacao.Falha;
            //        return Ok(resultado);
            //    }
            //}

            //if (dados.TipoAutenticacao == TipoAutenticacao.Local)
            //{
            //    identityServer = ConfigurationManager.AppSettings["IdentityServerLocal"];
            //}
            //else if (dados.TipoAutenticacao == TipoAutenticacao.Sparks)
            //{
            //    identityServer = ConfigurationManager.AppSettings["IdentityServerSparks"];
            //}
            //else if (dados.TipoAutenticacao == TipoAutenticacao.Tms)
            //{
            //    identityServer = ConfigurationManager.AppSettings["IdentityServerTms"];
            //}
            //else
            //{
            //    identityServer = ConfigurationManager.AppSettings["IdentityServer"];
            //}

            //var tokenClient = new TokenClient(identityServer + "/connect/token", dados.ClientId, dados.ClientSecret);
            //TokenResponse token = await tokenClient.RequestResourceOwnerPasswordAsync(dados.Username, dados.Password, dados.Scope);

            //dados.Password = string.Empty;

            //if (token == null || string.IsNullOrWhiteSpace(token.AccessToken))
            //{
            //    if (token != null && token.IsError)
            //    {
            //        JToken errorToken;
            //        if (token.Json != null &&
            //            token.Json.TryGetValue("error_description", out errorToken))
            //        {
            //           // throw new TcpMensagemException(errorToken.ToString());
            //        }
            //        else
            //        {
            //            //throw new TcpMensagemException("CAD-011");
            //        }
            //    }
            //    else
            //    {
            //        //throw new TcpMensagemException("CAD-011");
            //    }
            //}
            //else
            //{
            //    dados.RefreshToken = token.RefreshToken ?? "refresh_token";
            //    dados.Token = token.AccessToken;

            //    resultado.Status = ResultadoOperacao.Sucesso;
            //    resultado.Objeto = dados;
            //}

            var login = new LoginDataDto()
            {
                Username = "root",
                Password = "root",
                Token = "root",
                ClientId = "root",
                ClientSecret = "root",
                Scope = "root",
                RefreshToken = "root"
            };

            resultado.Objeto = login;

            return Ok(resultado);
        }
    }
}
