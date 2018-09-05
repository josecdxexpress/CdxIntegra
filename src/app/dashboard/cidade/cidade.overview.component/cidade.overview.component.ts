import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { CidadeDataService } from '../../../core/service/cidade.data.service';
import { PaginationService } from '../../../core/service/pagination.service';
import { Cidade } from '../../../model/cidade';
import { RootCidade } from '../../../model/cidade';

@Component({
  selector: 'app-cidade-overview',
  templateUrl: './templates/cidade.overview.component.html',
  styleUrls: ['./templates/cidade.overview.component.scss']
})
export class CidadeOverviewComponent implements OnInit {
    
  dataSource: Cidade[];
  totalCount: number;

  constructor(
  private cidadeDataService: CidadeDataService,
  private paginationService: PaginationService) { }

  ngOnInit(): void {
    this.getAllRequisicao('','');
}
 
switchPage(event: PageEvent) {
    this.paginationService.change(event);
    this.getAllRequisicao('', '');
}

getAllRequisicao(numero: string, referencia: string) {
  this.cidadeDataService.getAll<RootCidade>(numero, referencia)
      .subscribe((result: any) => {
          this.totalCount = result.body.totalRegistros;
          this.dataSource = result.body.objeto;
      });
    }
}
