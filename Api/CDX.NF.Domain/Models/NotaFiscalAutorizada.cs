using CDX.NF.Core.Infraestrutura.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDX.NF.Domain.Models
{
    /// <summary>
    /// Nota Fiscal Autorizada e Gerada. 
    /// </summary>
    [Table("NotaFiscalAutorizada")]
    public class NotaFiscalAutorizada : BaseEntidade
    {
        /// <summary>
        /// Número da nota fiscal gerada
        /// </summary>
        public int? PrestadorId { get; set; }

        public Prestador Prestador { get; set; }

        /// <summary>
        /// Identificador da tabela requisição
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Referencia { get; set; }

        public int? ServicoWsSoapId { get; set; }

        public ServicoWsSoap ServicoWsSoap { get; set; }

        /// <summary>
        /// Número da nota fiscal gerada
        /// </summary>
        [MaxLength(50)]
        public string Numero { get; set; }

        /// <summary>
        /// Código de verificação da nota fiscal
        /// </summary>
        [MaxLength(50)]
        public string CodigoVerificacao { get; set; }

        /// <summary>
        /// url da prefeitura contendo a nota fiscal 
        /// </summary>
        [MaxLength(200)]
        public string UrlPrefeitura { get; set; }

        /// <summary>
        /// Caminho do arquivo xml da nota fiscal 
        /// </summary>
        [MaxLength(200)]
        public string CaminhoNfe { get; set; }

        /// <summary>
        /// Caminho do arquivo xml da nota fiscal 
        /// </summary>
        [MaxLength(50)]
        public string Status { get; set; }

        /// <summary>
        /// Imagem da Nota fiscal em Base64
        /// </summary>
        [Column(TypeName = "varbinary(max)")]
        public byte[] ImagemNfe { get; set; }

        public DateTime DataEmissao { get; set; }

        public IList<Requisicao> Requisicoes { get; set; }
    }
}
