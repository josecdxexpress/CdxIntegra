using CDX.NF.Core.Infraestrutura.Persistence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDX.NF.Domain.Models
{
    [Table("Consultar")]
    public class Consultar : BaseEntidade
    {
        [MaxLength(20)]
        public bool Homologacao { get; set; }

        [MaxLength(20)]
        public string Cnpj_prestador { get; set; }

        [MaxLength(50)]
        public int Referencia { get; set; }
    }

    [Table("NotaFiscalSolicitada")]
    public class NotaFiscalSolicitada : BaseEntidade
    {
        public bool Homologacao { get; set; }

        public int Identificador_nota { get; set; }

        public int? AutorizarId { get; set; }
        public Autorizar Autorizar { get; set; }
    }

    [Table("Autorizar")]
    public class Autorizar : BaseEntidade
    {
        [MaxLength(30)]
        public string Data_emissao { get; set; }

        [MaxLength(50)]
        public string Natureza_operacao { get; set; }

        [MaxLength(30)]
        public string Optante_simples_nacional { get; set; }

        public int? PrestadorId { get; set; }
        public Prestador Prestador { get; set; }

        public int? TomadorId { get; set; }
        public Tomador Tomador { get; set; }

        public int? ServicoId { get; set; }
        public Servico Servico { get; set; }
    }


    [Table("Prestador")]
    public class Prestador : BaseEntidade
    {
        [MaxLength(20)]
        public string Cnpj { get; set; }

        [MaxLength(20)]
        public string Inscricao_municipal { get; set; }

        [MaxLength(20)]
        public string Codigo_municipio { get; set; }
    }

    [Table("Tomador")]
    public class Tomador : BaseEntidade
    {
        [MaxLength(20)]
        public string Cpf { get; set; }

        [MaxLength(200)]
        public string Razao_social { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }

    [Table("Endereco")]
    public class Endereco : BaseEntidade
    {
        [MaxLength(50)]
        public string Logradouro { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }

        [MaxLength(100)]
        public string Bairro { get; set; }

        [MaxLength(20)]
        public string Uf { get; set; }

        [MaxLength(20)]
        public string Cep { get; set; }
    }

    [Table("Servico")]
    public class Servico : BaseEntidade
    {
        [MaxLength(200)]
        public string Discriminacao { get; set; }

        [MaxLength(20)]
        public string Iss_retido { get; set; }

        [MaxLength(20)]
        public string Valor_iss { get; set; }

        [MaxLength(20)]
        public string Codigo_cnae { get; set; }

        [MaxLength(200)]
        public string Item_lista_servico { get; set; }

        [MaxLength(20)]
        public string Valor_servicos { get; set; }
    }
}
