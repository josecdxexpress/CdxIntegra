using System;
using System.Collections.Generic;

namespace CDX.NF.Api.Dto
{
    public class RetornoDto<T>
    {
        public RetornoDto()
        {
            Mensagens = new List<MensagemSistemaDto>();
        }

        public RetornoDto(T elemento)
        {
            Objeto = elemento;
            Mensagens = new List<MensagemSistemaDto>();
        }

        public List<MensagemSistemaDto> Mensagens { get; set; }

        public ResultadoOperacao Status { get; set; }

        public T Objeto { get; set; }

        public void AdicionarMensagem(TcpMensagemException ex)
        {
            if (ex == null || Mensagens == null)
            {
                Mensagens = new List<MensagemSistemaDto>();
            }

            Mensagens.Add(new MensagemSistemaDto
            {
                Identificador = ex.Identificador,
                Argumentos = ex.Argumentos
            });
        }

        public void AdicionarMensagem(ListaTcpMensagemException lista)
        {
            if (lista == null || Mensagens == null)
            {
                Mensagens = new List<MensagemSistemaDto>();
            }

            foreach (var ex in lista.Mensagens)
            {
                Mensagens.Add(new MensagemSistemaDto
                {
                    Identificador = ex.Identificador,
                    Argumentos = ex.Argumentos
                });
            }
        }

        public void AdicionarMensagem(string identificador, params string[] argumentos)
        {
            if (Mensagens == null)
            {
                Mensagens = new List<MensagemSistemaDto>();
            }

            Mensagens.Add(new MensagemSistemaDto
            {
                Identificador = identificador,
                Argumentos = argumentos
            });
        }

        //public class RetornoDto
        //{
        //    public RetornoNfeDto RetornoNfeDto { get; set; }

        //    public IList<MensagemRetornoDto> Mensagens { get; set; }
        //}

        //public class RetornoNfeDto
        //{
        //    public string Cnpj_prestado { get; set; }

        //    /// <summary>
        //    /// Sequencial de controle controle da api
        //    /// </summary>
        //    public string Ref { get; set; }

        //    public string Status { get; set; }

        //    public string Numero { get; set; }

        //    public string Codigo_verificacao { get; set; }

        //    public string Data_emissao { get; set; }

        //    public string Caminho_xml_nota_fiscal { get; set; }

        //    public string Retorno_nota { get; set; }
        //}

        //public class MensagemRetornoDto
        //{
        //    public string Codigo { get; set; }

        //    public string Mensagem { get; set; }
        //}
    }

    public class MensagemSistemaDto
    {
        //[DataMember]
        public string Titulo { get; set; }

        //[DataMember]
        public string Mensagem { get; set; }

        //[DataMember]
        public string Identificador { get; set; }

        //[DataMember]
        public int Nivel { get; set; }

        //[DataMember]
        public int Tipo { get; set; }

        //[DataMember]
        public string Elemento { get; set; }

        //[DataMember]
        public string Ajuda { get; set; }

        //[DataMember]
        public bool ApresentarCac { get; set; }

        //[IgnoreDataMember]
        public string Modulo { get; set; }

        //[IgnoreDataMember]
        public string[] Argumentos { get; set; }
    }
    public enum ResultadoOperacao
    {
        Indefinido = 0,

        Sucesso = 1,

        Falha = 2,

        Alerta = 3,

        Info = 4
    }

    public class TcpMensagemException : Exception
    {
        /// <summary>
        /// Tratamento de mensagem customizado do TCP
        /// </summary>
        /// <param name="identificador">Identificador da mensagem (ex: ADU-001)</param>
        /// <param name="args">Parametro opcional caso a mensagem tenha argumentos</param>
        public TcpMensagemException(string identificador, params string[] args)
            : base(identificador)
        {
            Identificador = identificador;
            Argumentos = args;
        }

        /// <summary>
        /// Tratamento de mensagem customizado do TCP
        /// </summary>
        /// <param name="modulo">Modulo/Frente da mensagem (ex: Aduaneiro)</param>
        /// <param name="identificador">Identificador da mensagem (ex: ADU-001) prefixo-codigo</param>
        /// <param name="innerException">Exception da mensagem</param>
        /// <param name="args">Parametro opcional caso a mensagem tenha argumentos</param>
        public TcpMensagemException(string modulo, string identificador, Exception innerException, params string[] args)
            : base(identificador, innerException)
        {
            Modulo = modulo;
            Identificador = identificador;
            Argumentos = args;
        }

        public string Modulo { get; set; }

        public string Identificador { get; set; }

        public string[] Argumentos { get; set; }
    }

    public class ListaTcpMensagemException : Exception
    {
        /// <summary>
        /// Tratamento de mensagem customizado do TCP
        /// </summary>
        /// <param name="mensagens">Lista de Mensagens</param>
        public ListaTcpMensagemException(List<TcpMensagemException> mensagens)
        {
            Mensagens = mensagens;
        }

        public List<TcpMensagemException> Mensagens { get; set; }
    }
}