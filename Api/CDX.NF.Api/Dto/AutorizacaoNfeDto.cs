using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Domain.Models;

namespace CDX.NF.Api.Dto
{
    /// <summary>
    /// Classe utilizada para solicitar a autorização de uma nota fiscal.
    /// </summary>
    public class AutorizacaoNfeDto
    {
        /// <summary>
        /// 1 - Url 2 - imagem
        /// </summary>
        public string FormaRetorno { get; set; }

        public AutenticacaoDto Autenticacao { get; set; }

        public NfeDto Nfe { get; set; }
    }
    public class NfeDto
    {
        public AutorizacaoDto Emissao { get; set; }

        public ConsultaDto Consulta { get; set; }
    }

    public class AutenticacaoDto
    {
        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string Token { get; set; }
    }

    public class ConsultaDto
    {
        public bool Homologacao { get; set; }

        public string Cnpj_prestador { get; set; }

        public string Referencia { get; set; }
    }

    public class AutorizacaoDto
    {
        public AutorizarDto Autorizar { get; set; }
    }

    public class AutorizarDto
    {
        public string Data_emissao { get; set; }

        public string Natureza_operacao { get; set; }

        public string Optante_simples_nacional { get; set; }

        public PrestadorDto Prestador { get; set; }

        public TomadorDto Tomador { get; set; }

        public ServicoDto Servico { get; set; }
    }

    public class PrestadorDto
    {
        public PrestadorDto(Prestador prestador)
        {
            if (prestador == null)
            {
                return;
            }


            Id = prestador.Id;
            Cnpj = prestador.Cnpj;
            Situacao = prestador.Situacao.Equals(SituacaoEnum.Ativo) ? "Ativo" : "Inativo";
        }

        public int? Id { get; set; }

        public string Cnpj { get; set; }

        public string Inscricao_municipal { get; set; }

        public string Codigo_municipio { get; set; }

        public string Situacao { get; set; }
    }

    public class TomadorDto
    {
        public string Cpf { get; set; }

        public string Razao_social { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public EnderecoDto Endereco { get; set; }
    }

    public class EnderecoDto
    {
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Uf { get; set; }

        public string Cep { get; set; }
    }

    public class ServicoDto
    {
        public string Discriminacao { get; set; }

        public string Iss_retido { get; set; }

        public string Valor_iss { get; set; }

        public string Codigo_cnae { get; set; }

        public string Item_lista_servico { get; set; }

        public string Valor_servicos { get; set; }
    }

    public class RetornoAutorizacaoDto
    {
        public string Cnpj_prestador { get; set; }

        public string Ref { get; set; }

        public string Status { get; set; }
    }
}