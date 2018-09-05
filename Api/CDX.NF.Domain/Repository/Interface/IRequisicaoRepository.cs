using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.Enum;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository.Interface
{
        /// <summary>
        /// Interface de repository para operações com a entidade nota fiscal.
        /// </summary>
    public interface IRequisicaoRepository
    {
        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Requisicao ObterTodos(int referencia, TipoOperacao tipoOperacao);

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        Requisicao ObterPorId(int id);

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        int Inserir(Requisicao requisicao);

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        void Alterar(Requisicao requisicao);

        /// <summary>
        /// Exclui logicamente uma nota fiscal
        /// </summary>
        void Excluir();

        Requisicao ObterTodosPorStatus(int referencia, TipoOperacao tipoOperacao, EtapaRequisicao etapa, StatusOperacao status);

        /* Async */

        /// <summary>
        /// Obtem todos por parametros
        /// </summary>
        Task<Requisicao> ObterTodosAsync(int referencia, TipoOperacao tipoOperacao);

        /// <summary>
        /// Obtem requisição por referencia, tipo de operação e etapa.
        /// </summary>
        Task<Requisicao> ObterTodosPorStatusAsync(int referencia, TipoOperacao tipoOperacao, EtapaRequisicao etapa, StatusOperacao status);

        /// <summary>
        /// Persiste um objeto requisição
        /// </summary>
        Task<int> InserirAsync(Requisicao requisicao);

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Requisicao> ObterPorIdAsync(int id);

        Task<IList<Requisicao>> Pesquisa(RequisicaoFiltroTo filtro, PesquisaTo pesquisa);
    }
}
