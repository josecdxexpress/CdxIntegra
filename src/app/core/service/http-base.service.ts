import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginationService } from './pagination.service';

@Injectable()
export class HttpBaseService {

    private headers = new HttpHeaders();
    private endpoint = `http://localhost:6064/Api/Usuario/`;

    constructor(
        private httpClient: HttpClient,
        private paginationService: PaginationService) {

        this.headers = this.headers.set('Content-Type', 'application/json');
        this.headers = this.headers.set('Accept', 'application/json');
    }

    get<T>() {
        const mergedUrl = `${this.endpoint}` +
            `?page=${this.paginationService.page}&pageCount=${this.paginationService.pageCount}`;

        return this.httpClient.get<T>(mergedUrl, { observe: 'response' });
    }

    getUrl<T>(url: string) {
        const mergedUrl = url + `&page=${this.paginationService.page}&pageCount=${this.paginationService.pageCount}`;

        return this.httpClient.get<T>(mergedUrl, { observe: 'response' });
    }

    getAll<T>(nome: string, login: string) {
        const mergedUrl = `${this.endpoint}` +
            `?nome=`+ nome + `&login=`+ login +
            `&page=${this.paginationService.page}&pageCount=${this.paginationService.pageCount}`;

        return this.httpClient.get<T>(mergedUrl, { observe: 'response' });
    }
 
    getSingle<T>(id: number) {
        return this.httpClient.get<T>(`${this.endpoint}${id}`);
    }

    add<T>(toAdd: T) {
        return this.httpClient.post<T>(this.endpoint, toAdd, { headers: this.headers });
    }

    update<T>(url: string, toUpdate: T) {
        return this.httpClient.put<T>(url,
            toUpdate,
            { headers: this.headers });
    }

    delete(url: string) {
        return this.httpClient.delete(url);
    }
}
