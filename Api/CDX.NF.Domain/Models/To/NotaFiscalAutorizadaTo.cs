using System;

namespace CDX.NF.Domain.Models.To
{
    public class NotaFiscalAutorizadaTo
    {
        public string Ref { get; set; }

        /// <summary>
        /// Identificador da tabela requisição
        /// </summary>
        public string Cnpj_prestador { get; set; }

        /// <summary>
        /// Status da nota fiscal gerada
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Número da nota fiscal gerada
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Código de verificação da nota fiscal
        /// </summary>
        public string Codigo_verificacao { get; set; }


        public string data_emissao { get; set; }

        /// <summary>
        /// url da prefeitura contendo a nota fiscal 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Caminho do arquivo xml da nota fiscal 
        /// </summary>
        public string caminho_xml_nota_fiscal { get; set; }

        /// <summary>
        /// Imagem da Nota fiscal em Base64
        /// </summary>
        public Byte[] Retorno_nota { get; set; }

        /// <summary>
        /// url da prefeitura contendo a nota fiscal 
        /// </summary>
        public string Mensagem { get; set; }
    }

    public class NotaFiscalAutorizadaTmpTo
    {
        public string Ref { get; set; }

        /// <summary>
        /// Identificador da tabela requisição
        /// </summary>
        public string Cnpj_prestador { get; set; }

        /// <summary>
        /// Status da nota fiscal gerada
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Número da nota fiscal gerada
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Código de verificação da nota fiscal
        /// </summary>
        public string Codigo_verificacao { get; set; }


        public string data_emissao { get; set; }

        /// <summary>
        /// url da prefeitura contendo a nota fiscal 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Caminho do arquivo xml da nota fiscal 
        /// </summary>
        public string caminho_xml_nota_fiscal { get; set; }

        /// <summary>
        /// Imagem da Nota fiscal em Base64
        /// </summary>
        public Byte[] Retorno_nota { get; set; }

        /// <summary>
        /// url da prefeitura contendo a nota fiscal 
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// url da prefeitura contendo a nota fiscal 
        /// </summary>
        public string Mensagem { get; set; }
    }
}
