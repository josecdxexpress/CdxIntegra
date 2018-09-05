using CDX.NF.Api.Dto;
using CDX.NF.Api.Extensoes;
using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Repository.Interface;
using CDX.NF.Domain.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly INotaFiscalService _notaFiscalBizService;

        public UploadController(INotaFiscalRepository notaFiscalRepository, INotaFiscalService notaFiscalBizService)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _notaFiscalBizService = notaFiscalBizService;
        }

        // GET api/files/sample.png
        [HttpGet("{fileName}")]
        public string Get(string fileName)
        {
            //string path = _hostingEnvironment.WebRootPath + "/images/" + fileName;
            //byte[] b = System.IO.File.ReadAllBytes(path);
            //return "data:image/png;base64," + Convert.ToBase64String(b);
            return null;
        }

        [HttpPost]
        public string Post([FromBody] AutorizacaoNfeDto autorizacaoNfeDto)
        {
            var resultado = new Retorno<string>();

            try
            {
                Retorno<RetornoServicoTo> retorno = _notaFiscalBizService.Autorizar(autorizacaoNfeDto.ToTransferObject());

                if (retorno.Status != ResultadoOperacao.Sucesso)
                {
                    resultado.Mensagens.AddRange(retorno.Mensagens);
                    resultado.Status = retorno.Status;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(resultado);
                }

                resultado.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(retorno.Objeto);
                resultado.Status = ResultadoOperacao.Sucesso;
            }
            catch (Exception ex)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Mensagem = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty) });
                resultado.Status = ResultadoOperacao.Falha;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(resultado);
        }
    }
}
