using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Core.Infraestrutura.Api
{
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
}