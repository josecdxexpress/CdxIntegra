import { Injectable } from '@angular/core';

import { Requisicao } from '../../model/requisicao';
import { HttpBaseService } from './http-base.service';

@Injectable()
export class RequisicaoDataService extends HttpBaseService {

    fireRequest(requisicao: Requisicao, method: string, url: string) {

        const links = requisicao.links
            ? requisicao.links.find(x => x.method === method)
            : null; 

        switch (method) {
            case 'GETALL': {
                return super.getUrl('http://localhost:6064/Api/Requisicao/' + url);
            }
            case 'DELETE': {
                //return super.delete(links.href);
                return super.delete('http://localhost:6064/Api/Requisicao/' + requisicao.id);
            }
            case 'POST': {
                return super.add<Requisicao>(requisicao);
            }
            case 'PUT': {
                return super.update<Requisicao>('http://localhost:6064/Api/Requisicao/', requisicao);
            }
            default: {
                console.log(`${links.method} not found!!!`);
                break;
            }
        }
    }

    getAll<T>(numero: string, referencia: string) {

        const mergedUrl = `http://localhost:6064/Api/Requisicao/` +
        `?numeroNota=`+ numero + `&referencia=`+ referencia;
        return super.getUrl<T>(mergedUrl);
    }
}
