using System.ComponentModel.DataAnnotations;

namespace CDX.NF.Domain.Models.Enum
{
    /// <summary>
    /// Status da requisição recebida pela api.
    /// 0 - Receida pela api e gerado número de requisição.
    /// 1 - Pendente envio para um serviço (Terceiro) de emissão.
    /// 3 - Com retorno do serviço (Terceiro)
    /// 4 - Processado
    /// </summary>
    public enum EtapaRequisicao
    {
        [Display(Name = "RecebidoPedido", Description = "Pedido Recebido")]
        RecebidoPedido = 1,
        [Display(Name = "PendenteEnvio", Description = "Pendente de Envio")]
        PendenteEnvio = 2,
        [Display(Name = "ComRetorno", Description = "Retorno Recebido")]
        ComRetorno = 3,
        [Display(Name = "Processada", Description = "Processado")]
        Processada = 4
    }

    /// <summary>
    /// Status retornado pelo serviço (Terceiro) ao qual foi enviada a solicitação da nota.
    /// </summary>
    public enum StatusOperacao
    {
        [Display(Name = "Indefinido", Description = "INDEFINIDO")]
        Indefinido = 0,
        [Display(Name = "ProcessandoOperacao", Description = "EM PROCESSAMENTO,")]
        ProcessandoOperacao = 1,    
        [Display(Name = "OperacaoEfetivada", Description = "AUTORIZADO")]
        OperacaoEfetivada = 2,       
        [Display(Name = "EfetivadaAnteriormente", Description = "EFETIVADA ANTERIORMENTE")]
        EfetivadaAnteriormente = 3,
        [Display(Name = "InformacaoNaoEncontrada", Description = "NÃO ENCONTRADO")]
        InformacaoNaoEncontrada = 4, 
        [Display(Name = "RequisicaoRejeitada", Description = "REJEITADO")]
        RequisicaoRejeitada = 5,     
        [Display(Name = "RequisicaoInvalida", Description = "REQUISICAO INVALIDA")]
        RequisicaoInvalida = 6,   
        [Display(Name = "EmpresaNaoHabilitada", Description = "EMPRESA NAO HABILITADA")]
        EmpresaNaoHabilitada = 7,    
        [Display(Name = "NfeCancelada", Description = "NFE CANCELADA")]
        NfeCancelada = 8,            
        [Display(Name = "PermissaoNegada", Description = "PERMISSAO NEGADA")]
        PermissaoNegada = 9,         
        [Display(Name = "NfeNaoAutorizada", Description = "NFE NAO AUTORIZADA")]
        NfeNaoAutorizada = 10,       
        [Display(Name = "NfeAutorizada", Description = "NFE AUTORIZADA")]
        NfeAutorizada = 11,          
        [Display(Name = "Erro", Description = "Erro")]
        Erro = 12                    
    }

    /// <summary>
    /// Serviços de terceiro disponíveis
    /// </summary>
    public enum WsSoapServices
    {
        [Display(Name = "MobLink", Description = "MobLink")]
        MobLink = 1,
        [Display(Name = "Outro", Description = "Outro")]
        Outro = 2
    }
}
