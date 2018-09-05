using CDX.NF.Domain.Models;
using CDX.NF.Api.Extensoes;

namespace CDX.NF.Api.Controllers
{
    /// <summary>
    /// Informações sobre as requisição
    /// </summary>
    public class RequisicaoDto
    {
        public RequisicaoDto(Requisicao re)
        {
            if (re == null)
            {
                return;
            }
            Id = re.Id;
            Referencia = re.Referencia;
            DscServicoWsSoap = re.ServicoWsSoap != null ? re.ServicoWsSoap.Descricao : string.Empty;
            NumeroNotaFiscal = re.NotaFiscalAutorizada != null ? re.NotaFiscalAutorizada.Numero : string.Empty;
            DscTipoOperacao = re.TipoOperacao.Description();
            DscPrestador = re.Prestador != null ? re.Prestador.Cnpj : string.Empty;
            ValorNota = re.ValorNota;
            DscCidade = re.Cidade != null ? re.Cidade.Descricao : string.Empty;
            DscEtapa = re.Etapa.Description();
            TempoExecucao = re.TempoExecucao;
            DscStatus = re.Status.Description();
            Erro = re.Erro;
            Observacao = re.Observacao;
        }

        public int? Id { get; set; }

        public int Referencia { get; set; }

        public string DscServicoWsSoap { get; set; }

        public string NumeroNotaFiscal { get; set; }

        public string DscTipoOperacao { get; set; }

        public string DscPrestador { get; set; }

        public string ValorNota { get; set; }

        public string DscCidade { get; set; }

        public string DscEtapa { get; set; }

        public float? TempoExecucao { get; set; }

        public string DscStatus { get; set; }

        public string Erro { get; set; }

        public string Observacao { get; set; }
    }
}