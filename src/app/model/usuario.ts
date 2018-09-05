// export class Usuario {
//   id: number;
//   name: string;
//   email: string;
//   login: string;
//   senha: string;
// }


export class Usuario {
  id?: number;
  nome: string;
  login?: any;
  senha?: any;
  email?: any;
  situacao: string;
  links: Link[];
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

export class RetornoUsuario {
  status: number;
  objeto: Usuario;
  mensagens?: mensagem[];
}


export class RootUsuario {
  parametros?: any;
  descricao?: any;
  mensagens?: mensagem[];
  status: number;
  objeto: Usuario[];
  incluirObsoletos: boolean;
  paginaAtual?: any;
  tamanhoPagina?: any;
  totalRegistros?: any;
  ordenacao?: any;
  sentidoOrdenacao: number;
}



// export class RootObject {
//   nome?: any;
//   login?: any;
// }