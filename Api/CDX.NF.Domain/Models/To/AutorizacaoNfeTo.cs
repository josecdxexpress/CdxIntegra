using System;

namespace CDX.NF.Domain.Models.To
{
    public class AutorizacaoNfeTo
    {
        /// <summary>
        /// 1 - Xml 2 - Link
        /// </summary>
        public string FormaRetorno { get; set; }

        public AutenticacaoTo Autenticacao { get; set; }

        public NfeTo Nfe { get; set; }
    }

    public class AutenticacaoTo
    {
        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string Token { get; set; }
    }

    public class NfeTo
    {
        public AutorizacaoTo CapaAutorizacaoNfse { get; set; }

        public ConsultarTo Consultar { get; set; }
    }

    public class ConsultarTo
    {
        public bool Homologacao { get; set; }

        public string Cnpj_prestador { get; set; }

        public string Identificador_nota { get; set; }
    }

    public class AutorizacaoTo
    {
        public bool Homologacao { get; set; }

        public int Identificador_nota { get; set; }

        public AutorizarTo Autorizar { get; set; }
    }

    public class AutorizarTo
    {
        public string Data_emissao { get; set; }

        public string Natureza_operacao { get; set; }

        public string Optante_simples_nacional { get; set; }

        public PrestadorTo Prestador { get; set; }

        public TomadorTo Tomador { get; set; }

        public ServicoTo Servico { get; set; }
    }

    public class PrestadorTo
    {
        public int? Id { get; set; }

        public string Cnpj { get; set; }

        public string Inscricao_municipal { get; set; }

        public string Codigo_municipio { get; set; }

        public string Situacao { get; set; }
    }

    public class TomadorTo
    {
        public string Cpf { get; set; }

        public string Razao_social { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public EnderecoTo Endereco { get; set; }
    }

    public class EnderecoTo
    {
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Uf { get; set; }

        public string Cep { get; set; }
    }

    public class ServicoTo
    {
        public string Discriminacao { get; set; }

        public string Iss_retido { get; set; }

        public string Valor_iss { get; set; }

        public string Codigo_cnae { get; set; }

        public string Item_lista_servico { get; set; }

        public string Valor_servicos { get; set; }
    }
}
