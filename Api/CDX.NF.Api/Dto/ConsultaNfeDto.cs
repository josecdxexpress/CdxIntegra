namespace CDX.NF.Api.Dto
{
    /// <summary>
    /// Classe utilizada para a consulta de uma nota fiscal.
    /// </summary>
    public class ConsultaNfeDto : NfeBaseDto
    {
        /// <summary>
        /// 1 - Url 2 - imagem
        /// </summary>
        public string FormaRetorno { get; set; }

        public string Numero { get; set; }
    }
}
