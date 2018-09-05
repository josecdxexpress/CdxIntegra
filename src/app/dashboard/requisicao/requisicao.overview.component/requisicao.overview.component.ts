import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { RequisicaoDataService } from '../../../core/service/requisicao.data.service';
import { PaginationService } from '../../../core/service/pagination.service';
import { Requisicao } from '../../../model/requisicao';
import { RootRequisicao } from '../../../model/requisicao';

@Component({
  selector: 'app-requisicao-overview',
  templateUrl: './templates/requisicao.overview.component.html',
  styleUrls: ['./templates/requisicao.overview.component.scss']
})
export class RequisicaoOverviewComponent implements OnInit {
    
  dataSource: Requisicao[];
  totalCount: number;

  constructor(
  private requisicaoDataService: RequisicaoDataService,
  private paginationService: PaginationService) { }

  ngOnInit(): void {
    this.getAllRequisicao('','');
}
 
switchPage(event: PageEvent) {
    this.paginationService.change(event);
    this.getAllRequisicao('', '');
}

getAllRequisicao(numero: string, referencia: string) {
  this.requisicaoDataService.getAll<RootRequisicao>(numero, referencia)
      .subscribe((result: any) => {
          this.totalCount = result.body.totalRegistros;
          this.dataSource = result.body.objeto;
      });
    }
}
