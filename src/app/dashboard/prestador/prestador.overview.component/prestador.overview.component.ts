import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { PrestadorDataService } from '../../../core/service/prestador.data.service';
import { PaginationService } from '../../../core/service/pagination.service';
import { Prestador } from '../../../model/prestador';
import { RootPrestador } from '../../../model/prestador';

@Component({
  selector: 'app-prestador-overview',
  templateUrl: './templates/prestador.overview.component.html',
  styleUrls: ['./templates/prestador.overview.component.scss']
})
export class PrestadorOverviewComponent implements OnInit {
    
  dataSource: Prestador[];
  totalCount: number;

  constructor(
  private prestadorDataService: PrestadorDataService,
  private paginationService: PaginationService) { }

  ngOnInit(): void {
    this.getAllRequisicao('','');
}
 
switchPage(event: PageEvent) {
    this.paginationService.change(event);
    this.getAllRequisicao('', '');
}

getAllRequisicao(numero: string, referencia: string) {
  this.prestadorDataService.getAll<RootPrestador>(numero, referencia)
      .subscribe((result: any) => {
          this.totalCount = result.body.totalRegistros;
          this.dataSource = result.body.objeto;
      });
    }
}
