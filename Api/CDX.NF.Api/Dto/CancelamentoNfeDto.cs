namespace CDX.NF.Api.Dto
{
    /// <summary>
    /// Classe utilizada para o cancelamento de uma nota fiscal.
    /// </summary>
    public class CancelamentoNfeDto : NfeBaseDto
    {
        public bool Homologação { get; set; }

        public string Justificativa { get; set; }
    }
}
