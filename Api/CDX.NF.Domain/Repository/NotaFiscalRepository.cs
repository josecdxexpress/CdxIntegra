using CDX.NF.Domain.Repository.Interface;
using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models.To;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CDX.NF.Domain.Models;
using System;
using CDX.NF.Core.Infraestrutura.Interfaces;
using CDX.NF.Domain.Models.To.Filtro;
using Newtonsoft.Json;
using CDX.NF.Domain.Models.To.Extensoes;
using System.IO;
using System.Globalization;
using CDX.NF.Core.Infraestrutura.Api;
using System.Threading;
using System.Diagnostics;

namespace CDX.NF.Domain.Repository
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly Contexto _db;
        private readonly IUow _uow;

        public NotaFiscalRepository(Contexto context, IUow uow)
        {
            _db = context;
            _uow = uow;
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public Retorno<NotaFiscalRetornoTo> ObterTodos(PesquisaNotaFiscalTo pesquisaTo) {

            var retorno = new Retorno<NotaFiscalRetornoTo>();

            var notaFiscalAutorizada = _db.NotaFiscalAutorizada
                .Where(p => p.Numero == pesquisaTo.Numero)
                .FirstOrDefaultAsync().Result;

            if (notaFiscalAutorizada == null)
            {
                retorno.Mensagens.Add(new MensagemSistemaDto() { Identificador = "CDXNF0001", Mensagem = string.Format("Não foi localizada nota fiscal com o numero {0}.", pesquisaTo.Numero) });
                retorno.Status = ResultadoOperacao.Alerta;
                return retorno;
            }

            var notaFiscalRetornoTo = new NotaFiscalRetornoTo()
            {
                Numero = notaFiscalAutorizada.Numero,
                Url = notaFiscalAutorizada.UrlPrefeitura,
                Imagem = Convert.ToBase64String(notaFiscalAutorizada.ImagemNfe)
            };

            retorno.Objeto = notaFiscalRetornoTo;
            retorno.Status = ResultadoOperacao.Sucesso;
            return retorno;
        }

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        public void ObterPorId() { }

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        public void Inserir() { }

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        public void Alterar() { }

        /// <summary>
        /// Exclui logicamente uma nota fiscal
        /// </summary>
        public void Excluir() { }
    }
}
