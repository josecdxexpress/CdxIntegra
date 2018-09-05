import { Injectable } from '@angular/core';

import { Usuario } from '../../model/usuario';
import { HttpBaseService } from './http-base.service';

@Injectable()
export class UsuarioDataService extends HttpBaseService {

    fireRequest(usuario: Usuario, method: string) {

        const links = usuario.links
            ? usuario.links.find(x => x.method === method)
            : null;

        switch (method) {
            case 'DELETE': {
                //return super.delete(links.href);
                return super.delete('http://localhost:6064/Api/Usuario/' + usuario.id);
            }
            case 'POST': {
                return super.add<Usuario>(usuario);
            }
            case 'PUT': {
                return super.update<Usuario>('http://localhost:6064/Api/Usuario/', usuario);
            }
            default: {
                console.log(`${links.method} not found!!!`);
                break;
            }
        }
    }
}
