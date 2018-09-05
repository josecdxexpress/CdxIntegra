export class Parametro {
    id?: any;
    Referencia: string;
    DscServicoWsSoap: string;
    NumeroNotaFiscal: string;
    DscTipoOperacao: string;
    DscPrestador: string;
    ValorNota: string;
    DscCidade: string;
    DscEtapa: string;
    TempoExecucao: string;
    DscStatus: string;
    Erro: string;
    Observacao: string;
    links: Link[];
    situacao: string;
  }
  
  export class Link {
      href: string;
      rel: string;
      method: string;
  }
  
  export class mensagem {
    titulo: string;
    mensagem: string;
    identificador: string;
  }
  
  export class RetornoParametro {
    status: number;
    objeto: Parametro;
    mensagens?: mensagem[];
  }

  export class RootParametro{
    parametros?: any;
    descricao?: any;
    mensagens?: mensagem[];
    status: number;
    objeto: Parametro[];
    incluirObsoletos: boolean;
    paginaAtual?: any;
    tamanhoPagina?: any;
    totalRegistros?: any;
    ordenacao?: any;
    sentidoOrdenacao: number;
  }
  