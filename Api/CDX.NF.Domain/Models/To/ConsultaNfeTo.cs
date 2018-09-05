using System;
using System.Collections.Generic;
using System.Text;

namespace CDX.NF.Domain.Models.To
{
    public class ConsultaNfeTo : NfeBaseTo
    {
        /// <summary>
        /// 1 - Url 2 - imagem
        /// </summary>
        public string FormaRetorno { get; set; }

        public string Numero { get; set; }
    }
}
