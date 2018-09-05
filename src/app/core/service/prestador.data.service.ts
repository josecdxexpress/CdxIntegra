import { Injectable } from '@angular/core';

import { Prestador } from '../../model/prestador';
import { HttpBaseService } from './http-base.service';

@Injectable()
export class PrestadorDataService extends HttpBaseService {

    fireRequest(requisicao: Prestador, method: string, url: string) {

        const links = requisicao.links
            ? requisicao.links.find(x => x.method === method)
            : null; 

        switch (method) {
            case 'GETALL': {
                return super.getUrl('http://localhost:6064/Api/Prestador/' + url);
            }
            case 'DELETE': {
                //return super.delete(links.href);
                return super.delete('http://localhost:6064/Api/Prestador/' + requisicao.id);
            }
            case 'POST': {
                return super.add<Prestador>(requisicao);
            }
            case 'PUT': {
                return super.update<Prestador>('http://localhost:6064/Api/Prestador/', requisicao);
            }
            default: {
                console.log(`${links.method} not found!!!`);
                break;
            }
        }
    }

    getAll<T>(numero: string, referencia: string) {

        const mergedUrl = `http://localhost:6064/Api/Prestador/` +
        `?numeroNota=`+ numero + `&referencia=`+ referencia;
        return super.getUrl<T>(mergedUrl);
    }
}
