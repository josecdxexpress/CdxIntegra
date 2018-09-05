export class Cidade {
    id?: any;
    Codigo: string;
    Descricao: string;
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
  
  export class RetornoCidade {
    status: number;
    objeto: Cidade;
    mensagens?: mensagem[];
  }

  export class RootCidade {
    parametros?: any;
    descricao?: any;
    mensagens?: mensagem[];
    status: number;
    objeto: Cidade[];
    incluirObsoletos: boolean;
    paginaAtual?: any;
    tamanhoPagina?: any;
    totalRegistros?: any;
    ordenacao?: any;
    sentidoOrdenacao: number;
  }
  