using CDX.NF.Api.Dto;
using CDX.NF.Domain.Models.To;

namespace CDX.NF.Api.Extensoes
{
    public static class ConsultaNfeDtoExtensoes
    {
        internal static ConsultaNfeTo ToTransferObject(this ConsultaNfeDto re)
        {
            return new ConsultaNfeTo()
            {
                FormaRetorno = re.FormaRetorno,
                Autenticacao = new AutenticacaoTo() { Usuario = re.Autenticacao.Usuario, Senha = re.Autenticacao.Senha, Token = re.Autenticacao.Token },
                Referencia = re.Referencia,
                Numero = re.Numero,
                CnpjPrestador = re.CnpjPrestador,
                CodigoMunicipio = re.CodigoMunicipio
            };
        }
    }
}