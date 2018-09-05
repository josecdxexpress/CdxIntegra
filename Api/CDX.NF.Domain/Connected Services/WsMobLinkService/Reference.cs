//------------------------------------------------------------------------------
// <gerado automaticamente>
//     Esse código foi gerado por uma ferramenta.
//     //
//     As alterações no arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </gerado automaticamente>
//------------------------------------------------------------------------------

namespace WsMobLinkService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WsMobLinkService.WSnfseSoap")]
    public interface WSnfseSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Autorizar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> AutorizarAsync(WsMobLinkService.CapaAutorizacaoNfse obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Consultar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> ConsultarAsync(WsMobLinkService.Consultar referencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ConsultarRetornoClasse", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<WsMobLinkService.RetornoConsulta> ConsultarRetornoClasseAsync(WsMobLinkService.Consultar referencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Consultar_testes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> Consultar_testesAsync(string referencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ConsultarRetornoClassetestes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<WsMobLinkService.RetornoConsulta> ConsultarRetornoClassetestesAsync(string referencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Cancelar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> CancelarAsync(WsMobLinkService.Cancelar referencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Cancelar_testes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> Cancelar_testesAsync(string referencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GerarNfse", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> GerarNfseAsync(int id_grv, bool _isdev);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CapaAutorizacaoNfse
    {
        
        private Autorizar autorizarField;
        
        private bool homologacaoField;
        
        private int identificador_notaField;
        
        private int id_usuarioField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public Autorizar autorizar
        {
            get
            {
                return this.autorizarField;
            }
            set
            {
                this.autorizarField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public bool homologacao
        {
            get
            {
                return this.homologacaoField;
            }
            set
            {
                this.homologacaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int identificador_nota
        {
            get
            {
                return this.identificador_notaField;
            }
            set
            {
                this.identificador_notaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int id_usuario
        {
            get
            {
                return this.id_usuarioField;
            }
            set
            {
                this.id_usuarioField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Autorizar
    {
        
        private string data_emissaoField;
        
        private string natureza_operacaoField;
        
        private string regime_especial_tributacaoField;
        
        private string optante_simples_nacionalField;
        
        private string incentivador_culturalField;
        
        private string tributacao_rpsField;
        
        private string codigo_obraField;
        
        private string artField;
        
        private Prestador prestadorField;
        
        private Tomador tomadorField;
        
        private Servico servicoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string data_emissao
        {
            get
            {
                return this.data_emissaoField;
            }
            set
            {
                this.data_emissaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string natureza_operacao
        {
            get
            {
                return this.natureza_operacaoField;
            }
            set
            {
                this.natureza_operacaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string regime_especial_tributacao
        {
            get
            {
                return this.regime_especial_tributacaoField;
            }
            set
            {
                this.regime_especial_tributacaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string optante_simples_nacional
        {
            get
            {
                return this.optante_simples_nacionalField;
            }
            set
            {
                this.optante_simples_nacionalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string incentivador_cultural
        {
            get
            {
                return this.incentivador_culturalField;
            }
            set
            {
                this.incentivador_culturalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string tributacao_rps
        {
            get
            {
                return this.tributacao_rpsField;
            }
            set
            {
                this.tributacao_rpsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string codigo_obra
        {
            get
            {
                return this.codigo_obraField;
            }
            set
            {
                this.codigo_obraField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string art
        {
            get
            {
                return this.artField;
            }
            set
            {
                this.artField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public Prestador prestador
        {
            get
            {
                return this.prestadorField;
            }
            set
            {
                this.prestadorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public Tomador tomador
        {
            get
            {
                return this.tomadorField;
            }
            set
            {
                this.tomadorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public Servico servico
        {
            get
            {
                return this.servicoField;
            }
            set
            {
                this.servicoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Prestador
    {
        
        private string cnpjField;
        
        private string inscricao_municipalField;
        
        private string codigo_municipioField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string cnpj
        {
            get
            {
                return this.cnpjField;
            }
            set
            {
                this.cnpjField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string inscricao_municipal
        {
            get
            {
                return this.inscricao_municipalField;
            }
            set
            {
                this.inscricao_municipalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string codigo_municipio
        {
            get
            {
                return this.codigo_municipioField;
            }
            set
            {
                this.codigo_municipioField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Cancelar
    {
        
        private string referenciaField;
        
        private string justificativaField;
        
        private bool homologacaoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string referencia
        {
            get
            {
                return this.referenciaField;
            }
            set
            {
                this.referenciaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string justificativa
        {
            get
            {
                return this.justificativaField;
            }
            set
            {
                this.justificativaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool homologacao
        {
            get
            {
                return this.homologacaoField;
            }
            set
            {
                this.homologacaoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class RetornoConsulta
    {
        
        private string cnpj_prestadorField;
        
        private string refField;
        
        private string statusField;
        
        private string numeroField;
        
        private string codigo_verificacaoField;
        
        private System.DateTime data_emissaoField;
        
        private string urlField;
        
        private string caminho_xml_nota_fiscalField;
        
        private byte[] retorno_notaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string cnpj_prestador
        {
            get
            {
                return this.cnpj_prestadorField;
            }
            set
            {
                this.cnpj_prestadorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string @ref
        {
            get
            {
                return this.refField;
            }
            set
            {
                this.refField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string codigo_verificacao
        {
            get
            {
                return this.codigo_verificacaoField;
            }
            set
            {
                this.codigo_verificacaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public System.DateTime data_emissao
        {
            get
            {
                return this.data_emissaoField;
            }
            set
            {
                this.data_emissaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string caminho_xml_nota_fiscal
        {
            get
            {
                return this.caminho_xml_nota_fiscalField;
            }
            set
            {
                this.caminho_xml_nota_fiscalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=8)]
        public byte[] retorno_nota
        {
            get
            {
                return this.retorno_notaField;
            }
            set
            {
                this.retorno_notaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Consultar
    {
        
        private string referenciaField;
        
        private string cnpj_prestadorField;
        
        private bool homologacaoField;
        
        private int id_usuarioField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string referencia
        {
            get
            {
                return this.referenciaField;
            }
            set
            {
                this.referenciaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string cnpj_prestador
        {
            get
            {
                return this.cnpj_prestadorField;
            }
            set
            {
                this.cnpj_prestadorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool homologacao
        {
            get
            {
                return this.homologacaoField;
            }
            set
            {
                this.homologacaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int id_usuario
        {
            get
            {
                return this.id_usuarioField;
            }
            set
            {
                this.id_usuarioField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Servico
    {
        
        private string aliquotaField;
        
        private string discriminacaoField;
        
        private string iss_retidoField;
        
        private string item_lista_servicoField;
        
        private string codigo_tributario_municipioField;
        
        private string valor_servicosField;
        
        private string valor_deducoesField;
        
        private string valor_pisField;
        
        private string valor_cofinsField;
        
        private string valor_inssField;
        
        private string valor_irField;
        
        private string valor_csllField;
        
        private string valor_issField;
        
        private string valor_iss_retidoField;
        
        private string outras_retencoesField;
        
        private string base_calculoField;
        
        private string desconto_incondicionadoField;
        
        private string desconto_condicionadoField;
        
        private string codigo_cnaeField;
        
        private string codigo_municipioField;
        
        private string percentual_total_tributosField;
        
        private string fonte_total_tributosField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string aliquota
        {
            get
            {
                return this.aliquotaField;
            }
            set
            {
                this.aliquotaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string discriminacao
        {
            get
            {
                return this.discriminacaoField;
            }
            set
            {
                this.discriminacaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string iss_retido
        {
            get
            {
                return this.iss_retidoField;
            }
            set
            {
                this.iss_retidoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string item_lista_servico
        {
            get
            {
                return this.item_lista_servicoField;
            }
            set
            {
                this.item_lista_servicoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string codigo_tributario_municipio
        {
            get
            {
                return this.codigo_tributario_municipioField;
            }
            set
            {
                this.codigo_tributario_municipioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string valor_servicos
        {
            get
            {
                return this.valor_servicosField;
            }
            set
            {
                this.valor_servicosField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string valor_deducoes
        {
            get
            {
                return this.valor_deducoesField;
            }
            set
            {
                this.valor_deducoesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string valor_pis
        {
            get
            {
                return this.valor_pisField;
            }
            set
            {
                this.valor_pisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string valor_cofins
        {
            get
            {
                return this.valor_cofinsField;
            }
            set
            {
                this.valor_cofinsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string valor_inss
        {
            get
            {
                return this.valor_inssField;
            }
            set
            {
                this.valor_inssField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string valor_ir
        {
            get
            {
                return this.valor_irField;
            }
            set
            {
                this.valor_irField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string valor_csll
        {
            get
            {
                return this.valor_csllField;
            }
            set
            {
                this.valor_csllField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string valor_iss
        {
            get
            {
                return this.valor_issField;
            }
            set
            {
                this.valor_issField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string valor_iss_retido
        {
            get
            {
                return this.valor_iss_retidoField;
            }
            set
            {
                this.valor_iss_retidoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string outras_retencoes
        {
            get
            {
                return this.outras_retencoesField;
            }
            set
            {
                this.outras_retencoesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string base_calculo
        {
            get
            {
                return this.base_calculoField;
            }
            set
            {
                this.base_calculoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string desconto_incondicionado
        {
            get
            {
                return this.desconto_incondicionadoField;
            }
            set
            {
                this.desconto_incondicionadoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string desconto_condicionado
        {
            get
            {
                return this.desconto_condicionadoField;
            }
            set
            {
                this.desconto_condicionadoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string codigo_cnae
        {
            get
            {
                return this.codigo_cnaeField;
            }
            set
            {
                this.codigo_cnaeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string codigo_municipio
        {
            get
            {
                return this.codigo_municipioField;
            }
            set
            {
                this.codigo_municipioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string percentual_total_tributos
        {
            get
            {
                return this.percentual_total_tributosField;
            }
            set
            {
                this.percentual_total_tributosField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string fonte_total_tributos
        {
            get
            {
                return this.fonte_total_tributosField;
            }
            set
            {
                this.fonte_total_tributosField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Endereco
    {
        
        private string logradouroField;
        
        private string tipo_logradouroField;
        
        private string numeroField;
        
        private string complementoField;
        
        private string bairroField;
        
        private string codigo_municipioField;
        
        private string ufField;
        
        private string cepField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string logradouro
        {
            get
            {
                return this.logradouroField;
            }
            set
            {
                this.logradouroField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string tipo_logradouro
        {
            get
            {
                return this.tipo_logradouroField;
            }
            set
            {
                this.tipo_logradouroField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string complemento
        {
            get
            {
                return this.complementoField;
            }
            set
            {
                this.complementoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string bairro
        {
            get
            {
                return this.bairroField;
            }
            set
            {
                this.bairroField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string codigo_municipio
        {
            get
            {
                return this.codigo_municipioField;
            }
            set
            {
                this.codigo_municipioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string uf
        {
            get
            {
                return this.ufField;
            }
            set
            {
                this.ufField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string cep
        {
            get
            {
                return this.cepField;
            }
            set
            {
                this.cepField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Tomador
    {
        
        private string cnpjField;
        
        private string cpfField;
        
        private string razao_socialField;
        
        private string emailField;
        
        private string inscricao_municipalField;
        
        private string telefoneField;
        
        private Endereco enderecoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string cnpj
        {
            get
            {
                return this.cnpjField;
            }
            set
            {
                this.cnpjField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string cpf
        {
            get
            {
                return this.cpfField;
            }
            set
            {
                this.cpfField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string razao_social
        {
            get
            {
                return this.razao_socialField;
            }
            set
            {
                this.razao_socialField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string inscricao_municipal
        {
            get
            {
                return this.inscricao_municipalField;
            }
            set
            {
                this.inscricao_municipalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string telefone
        {
            get
            {
                return this.telefoneField;
            }
            set
            {
                this.telefoneField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public Endereco endereco
        {
            get
            {
                return this.enderecoField;
            }
            set
            {
                this.enderecoField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public interface WSnfseSoapChannel : WsMobLinkService.WSnfseSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public partial class WSnfseSoapClient : System.ServiceModel.ClientBase<WsMobLinkService.WSnfseSoap>, WsMobLinkService.WSnfseSoap
    {
        
    /// <summary>
    /// Implemente este método parcial para configurar o ponto de extremidade de serviço.
    /// </summary>
    /// <param name="serviceEndpoint">O ponto de extremidade a ser configurado</param>
    /// <param name="clientCredentials">As credenciais do cliente</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WSnfseSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(WSnfseSoapClient.GetBindingForEndpoint(endpointConfiguration), WSnfseSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSnfseSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WSnfseSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSnfseSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WSnfseSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSnfseSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string> AutorizarAsync(WsMobLinkService.CapaAutorizacaoNfse obj)
        {
            return base.Channel.AutorizarAsync(obj);
        }
        
        public System.Threading.Tasks.Task<string> ConsultarAsync(WsMobLinkService.Consultar referencia)
        {
            return base.Channel.ConsultarAsync(referencia);
        }
        
        public System.Threading.Tasks.Task<WsMobLinkService.RetornoConsulta> ConsultarRetornoClasseAsync(WsMobLinkService.Consultar referencia)
        {
            return base.Channel.ConsultarRetornoClasseAsync(referencia);
        }
        
        public System.Threading.Tasks.Task<string> Consultar_testesAsync(string referencia)
        {
            return base.Channel.Consultar_testesAsync(referencia);
        }
        
        public System.Threading.Tasks.Task<WsMobLinkService.RetornoConsulta> ConsultarRetornoClassetestesAsync(string referencia)
        {
            return base.Channel.ConsultarRetornoClassetestesAsync(referencia);
        }
        
        public System.Threading.Tasks.Task<string> CancelarAsync(WsMobLinkService.Cancelar referencia)
        {
            return base.Channel.CancelarAsync(referencia);
        }
        
        public System.Threading.Tasks.Task<string> Cancelar_testesAsync(string referencia)
        {
            return base.Channel.Cancelar_testesAsync(referencia);
        }
        
        public System.Threading.Tasks.Task<string> GerarNfseAsync(int id_grv, bool _isdev)
        {
            return base.Channel.GerarNfseAsync(id_grv, _isdev);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSnfseSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.WSnfseSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Não foi possível encontrar o ponto de extremidade com o nome \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSnfseSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://179.107.47.91:81/WSnfse.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.WSnfseSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://179.107.47.91:81/WSnfse.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Não foi possível encontrar o ponto de extremidade com o nome \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            WSnfseSoap,
            
            WSnfseSoap12,
        }
    }
}
