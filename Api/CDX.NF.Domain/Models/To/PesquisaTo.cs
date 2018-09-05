using CDX.NF.Core.Infraestrutura.Services.Tos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Domain.Models.To
{
    public class PesquisaTo2
    {
        ///// <summary>
        ///// 1 - Url 2 - imagem
        ///// </summary>
        //public string FormaRetorno { get; set; }

        //public string Numero { get; set; }

        public PesquisaTo2()
        {
            IncluirObsoletos = false;
        }

        public bool IncluirObsoletos { get; set; }

        public int? PaginaAtual { get; set; }

        public int? TamanhoPagina { get; set; }

        public int TotalRegistros { get; set; }

        public string Ordenacao { get; set; }

        public SentidoOrdenacao SentidoOrdenacao { get; set; }
    }
}
