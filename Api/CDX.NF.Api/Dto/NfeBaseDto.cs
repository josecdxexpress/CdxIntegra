using CDX.NF.Domain.Models.To;

namespace CDX.NF.Api.Dto
{
    /// <summary>
    /// Classe de informações basicas a serem fornecidas durante as requisições aos controlers.
    /// </summary>
    public class NfeBaseDto
    {
        public AutenticacaoTo Autenticacao { get; set; }

        public string Referencia { get; set; }

        public string CodigoMunicipio { get; set; }

        public string CnpjPrestador { get; set; }
    }
}
