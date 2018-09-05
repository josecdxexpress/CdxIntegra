using CDX.NF.Api.Dto;
using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using System;

namespace CDX.NF.Api.Extensoes
{
    public static class UsuarioDtoExtensoes
    {
        internal static Usuario ToEntity(this UsuarioDto re)
        {
            return new Usuario()
            {
                Nome = re.Nome,
                Login = re.Login,
                Senha = re.Senha,
                Email = re.Email,
                Situacao = (SituacaoEnum)Convert.ToInt32(re.Situacao)
            };
        }

 
        internal static UsuarioTo ToTransferObject(this UsuarioDto re)
        {
            return new UsuarioTo()
            {
                Id = re.Id,
                Nome = re.Nome,
                Login = re.Login,
                Senha = re.Senha,
                Email = re.Email,
                Situacao = re.Situacao
            };
        }
    }
}
