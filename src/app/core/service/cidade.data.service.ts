import { Injectable } from '@angular/core';

import { Cidade } from '../../model/cidade';
import { HttpBaseService } from './http-base.service';

@Injectable()
export class CidadeDataService extends HttpBaseService {

    fireRequest(requisicao: Cidade, method: string, url: string) {

        const links = requisicao.links
            ? requisicao.links.find(x => x.method === method)
            : null; 

        switch (method) {
            case 'GETALL': {
                return super.getUrl('http://localhost:6064/Api/Cidade/' + url);
            }
            case 'DELETE': {
                //return super.delete(links.href);
                return super.delete('http://localhost:6064/Api/Cidade/' + requisicao.id);
            }
            case 'POST': {
                return super.add<Cidade>(requisicao);
            }
            case 'PUT': {
                return super.update<Cidade>('http://localhost:6064/Api/Cidade/', requisicao);
            }
            default: {
                console.log(`${links.method} not found!!!`);
                break;
            }
        }
    }

    getAll<T>(numero: string, referencia: string) {

        const mergedUrl = `http://localhost:6064/Api/Cidade/` +
        `?numeroNota=`+ numero + `&referencia=`+ referencia;
        return super.getUrl<T>(mergedUrl);
    }
}
