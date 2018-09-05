export class Prestador {
    id?: any;
    Nome: string;
    Cnpj: string;
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
  
  export class RetornoPrestador {
    status: number;
    objeto: Prestador;
    mensagens?: mensagem[];
  }

  export class RootPrestador {
    parametros?: any;
    descricao?: any;
    mensagens?: mensagem[];
    status: number;
    objeto: Prestador[];
    incluirObsoletos: boolean;
    paginaAtual?: any;
    tamanhoPagina?: any;
    totalRegistros?: any;
    ordenacao?: any;
    sentidoOrdenacao: number;
  }
  