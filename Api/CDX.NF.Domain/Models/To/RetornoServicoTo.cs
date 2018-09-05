namespace CDX.NF.Domain.Models.To.Filtro
{
    /// <summary>
    /// Retorno de requisição ao serviço Terceiro.
    /// </summary>
    public class RetornoServicoTo
    {
        public int Ref { get; set; }

        public string Cnpj_prestador { get; set; }

        public string Codigo_municipo { get; set; }

        public string Status { get; set; }

        public string Mensagem { get; set; }
    }

    /// <summary>
    /// Retorno de requisição ao serviço Terceiro.
    /// </summary>
    public class RetornoServicoTmpTo
    {
        public int Ref { get; set; }

        public string Cnpj_prestador { get; set; }

        public string Codigo_municipo { get; set; }

        public string Status { get; set; }

        public string Codigo { get; set; }

        public string Mensagem { get; set; }
    }
}
