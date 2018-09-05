using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Dto
{
    /// <summary>
    /// Informações sobre os parametros
    /// </summary>
    public class ParametrosDto
    {
        public ParametrosDto(Parametros re)
        {
            if (re == null)
            {
                return;
            }
            Id = re.Id;
            DscServicoWsSoap = re.ServicoWsSoap != null ? re.ServicoWsSoap.Descricao : string.Empty;
            DscPrestador = re.Prestador != null ? re.Prestador.Cnpj : string.Empty;
            DscCidade = re.Cidade != null ? re.Cidade.Descricao : string.Empty;
            Alicota = re.Alicota;
            Certificado = re.Certificado;
            UtilizaCertificado = re.UtilizaCertificado;
            BloqueioEmissao = re.BloqueioEmissao;
        }

        public int? Id { get; set; }

        public string DscCidade { get; set; }

        public string DscPrestador { get; set; }

        public string DscServicoWsSoap { get; set; }

        public float Alicota { get; set; }

        public string Certificado { get; set; }

        public bool UtilizaCertificado { get; set; }

        public bool BloqueioEmissao { get; set; }
    }
}