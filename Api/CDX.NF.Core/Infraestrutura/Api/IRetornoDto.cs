using System.Collections.Generic;

namespace CDX.NF.Core.Infraestrutura.Api
{
    public interface IRetornoDto
    {
        List<MensagemSistemaDto> Mensagens { get; set; }
        ResultadoOperacao Status { get; set; }

        void AdicionarMensagem(TcpMensagemException ex);
        void AdicionarMensagem(string identificador, params string[] argumentos);
        void AdicionarMensagem(ListaTcpMensagemException lista);
    }
}
