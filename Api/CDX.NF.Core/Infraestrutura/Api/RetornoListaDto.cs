using System.Collections.Generic;

namespace CDX.NF.Core.Infraestrutura.Api
{
    public class RetornoListaDto<T> : PesquisaBase, IRetornoLista, IRetornoDto
    {
        public RetornoListaDto() { }

        public List<Parametro> Parametros { get; set; }
        public string Descricao { get; set; }
        public List<MensagemSistemaDto> Mensagens { get; set; }
        public ResultadoOperacao Status { get; set; }
        public List<T> Objeto { get; set; }

        public void AdicionarMensagem(TcpMensagemException ex) { }
        public void AdicionarMensagem(ListaTcpMensagemException lista) { }
        public void AdicionarMensagem(string identificador, params string[] argumentos) { }
        public object[] ObterDados() { return null; }
        public string ObterDescricao() { return null; }
        public List<Parametro> ObterParametros() { return null; }
    }
}
