export class Requisicao {
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
  
  export class RetornoRequisicao {
    status: number;
    objeto: Requisicao;
    mensagens?: mensagem[];
  }

  export class RootRequisicao {
    parametros?: any;
    descricao?: any;
    mensagens?: mensagem[];
    status: number;
    objeto: Requisicao[];
    incluirObsoletos: boolean;
    paginaAtual?: any;
    tamanhoPagina?: any;
    totalRegistros?: any;
    ordenacao?: any;
    sentidoOrdenacao: number;
  }
  