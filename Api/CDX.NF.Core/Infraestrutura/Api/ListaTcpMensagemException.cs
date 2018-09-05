using System;
using System.Collections.Generic;

namespace CDX.NF.Core.Infraestrutura.Api
{
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
