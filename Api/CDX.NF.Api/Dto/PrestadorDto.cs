using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Dto
{
    public class PrestadorDto2
    {
        public PrestadorDto2()
        {
        }

        public PrestadorDto2(Prestador prestador)
        {
            if (prestador == null)
            {
                return;
            }


            Id = prestador.Id;
            Cnpj = prestador.Cnpj;
            Situacao = prestador.Situacao.Equals(SituacaoEnum.Ativo) ? "Ativo" : "Inativo";
        }

        public int? Id { get; set; }

        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public string Situacao { get; set; }
    }
}