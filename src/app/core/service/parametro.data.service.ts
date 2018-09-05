import { Injectable } from '@angular/core';

import { Parametro } from '../../model/parametro';
import { HttpBaseService } from './http-base.service';

@Injectable()
export class ParametroDataService extends HttpBaseService {

    fireRequest(requisicao: Parametro, method: string, url: string) {

        const links = requisicao.links
            ? requisicao.links.find(x => x.method === method)
            : null; 

        switch (method) {
            case 'GETALL': {
                return super.getUrl('http://localhost:6064/Api/Parametro/' + url);
            }
            case 'DELETE': {
                //return super.delete(links.href);
                return super.delete('http://localhost:6064/Api/Parametro/' + requisicao.id);
            }
            case 'POST': {
                return super.add<Parametro>(requisicao);
            }
            case 'PUT': {
                return super.update<Parametro>('http://localhost:6064/Api/Parametro/', requisicao);
            }
            default: {
                console.log(`${links.method} not found!!!`);
                break;
            }
        }
    }

    getAll<T>(numero: string, referencia: string) {

        const mergedUrl = `http://localhost:6064/Api/Parametro/` +
        `?numeroNota=`+ numero + `&referencia=`+ referencia;
        return super.getUrl<T>(mergedUrl);
    }
}
