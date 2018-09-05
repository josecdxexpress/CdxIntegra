using System.ComponentModel;

namespace CDX.NF.Domain.Models.Enum
{
    /// <summary>
    /// Situação (Inativo, Ativo, Excluido)
    /// </summary>
    public enum SituacaoEnum
    {
        [Description("Inativo")]
        Inativo = 0,
        [Description("Ativo")]
        Ativo = 1,
        [Description("Excluido")]
        Excluido = 2
    }

    /// <summary>
    /// TipoOperacao (Autorizacao, Consulta, Cancelamento)
    /// </summary>
    public enum TipoOperacao
    {
        [Description("Autorizacao")]
        Autorizacao = 1,
        [Description("Consulta")]
        Consulta = 2,
        [Description("Cancelamento")]
        Cancelamento = 3
    }

    //[LookupTable]
    public enum TipoAutenticacao
    {
        [Description("Indefinido")]
        Indefinido = 0,

        [Description("Active Directory")]
        ActiveDirectory = 1,

        [Description("Local")]
        Local = 2,

        [Description("Sparks")]
        Sparks = 3,

        [Description("Tms")]
        Tms = 4
    }
}
