import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ParametroDataService } from '../../../core/service/parametro.data.service';
import { PaginationService } from '../../../core/service/pagination.service';
import { Parametro } from '../../../model/parametro';
import { RootParametro } from '../../../model/parametro';

@Component({
  selector: 'app-parametro-overview',
  templateUrl: './templates/parametro.overview.component.html',
  styleUrls: ['./templates/parametro.overview.component.scss']
})
export class ParametroOverviewComponent implements OnInit {
    
  dataSource: Parametro[];
  totalCount: number;

  constructor(
  private parametroDataService: ParametroDataService,
  private paginationService: PaginationService) { }

  ngOnInit(): void {
    this.getAllRequisicao('','');
}
 
switchPage(event: PageEvent) {
    this.paginationService.change(event);
    this.getAllRequisicao('', '');
}

getAllRequisicao(numero: string, referencia: string) {
  this.parametroDataService.getAll<RootParametro>(numero, referencia)
      .subscribe((result: any) => {
          this.totalCount = result.body.totalRegistros;
          this.dataSource = result.body.objeto;
      });
    }
}
