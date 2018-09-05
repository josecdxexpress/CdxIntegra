using CDX.NF.Api.Dto;
using CDX.NF.Domain.Models.To;

namespace CDX.NF.Api.Extensoes
{
    public static class CancelamentoNfeDtoExtensoes
    {
        internal static CancelamentoNfeTo ToTransferObject(this CancelamentoNfeDto re)
        {
            return new CancelamentoNfeTo()
            {
                Autenticacao = new AutenticacaoTo() { Usuario = re.Autenticacao.Usuario, Senha = re.Autenticacao.Senha, Token = re.Autenticacao.Token },
                Referencia = re.Referencia,
                Justificativa = re.Justificativa,
                Homologacao = false,
                CodigoMunicipio = re.CodigoMunicipio,
                CnpjPrestador = re.CnpjPrestador
            };
        }
    }
}
