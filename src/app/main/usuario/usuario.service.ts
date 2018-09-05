import { Injectable, EventEmitter } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs';
import { Usuario } from '../../model/usuario';
import { RootUsuario } from '../../model/usuario';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UsuarioService {

  usuarioChanged = new EventEmitter<Observable<Usuario[]>>();

  private url: string  = 'http://localhost:6064/Api/Usuario';
  
  constructor(private http: HttpClient) { }

  listar() {
    return this.http.get<RootUsuario>(this.url + '?IncluirObsoletos=false&Ordenacao=&PaginaAtual=1&SentidoOrdenacao=1&TamanhoPagina=20&TotalRegistros=0');
  }

  getAll(){
    return this.http.get<Usuario>(this.url);
  }

  add(record){
    return this.http.post(this.url, record);
  }

  private getHeaders(){
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    return headers;
  }

  private handleError(error: any) {
    let erro = error.message || 'Server error';
    console.error('Ocorreu um erro', error);
    return Observable.throw(erro);
  }
}