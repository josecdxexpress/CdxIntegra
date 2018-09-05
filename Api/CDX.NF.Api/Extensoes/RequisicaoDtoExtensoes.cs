using CDX.NF.Api.Controllers;
using CDX.NF.Domain.Models.To;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Extensoes
{
    public static class RequisicaoDtoExtensoes
    {
        internal static RequisicaoTo ToTransferObject(this RequisicaoDto re)
        {
            return new RequisicaoTo()
            {
                Referencia = re.Referencia,
                DscServicoWsSoap = re.DscServicoWsSoap,
                NumeroNotaFiscal = re.NumeroNotaFiscal,
                DscTipoOperacao = re.DscTipoOperacao,
                DscPrestador = re.DscPrestador,
                ValorNota = re.ValorNota,
                DscCidade = re.DscCidade,
                DscEtapa = re.DscEtapa,
                TempoExecucao = re.TempoExecucao,
                DscStatus = re.DscStatus,
                Erro = re.Erro,
                Observacao = re.Observacao
            };
        }
    }
}
