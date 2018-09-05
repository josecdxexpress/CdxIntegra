import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { RequisicaoDataService } from '../../../core/service/requisicao.data.service';
import { PaginationService } from '../../../core/service/pagination.service';
import { Requisicao } from '../../../model/requisicao';
import { RootRequisicao } from '../../../model/requisicao';
import { ParametroOverviewComponent } from '../parametro.overview.component/parametro.overview.component';
import { MatPaginator, MatTableDataSource, MatFormField, MatFormFieldControl } from '@angular/material';

@Component({
  selector: 'app-parametro-lista',
  templateUrl: './templates/parametro.list.component.html',
  styleUrls: ['./templates/parametro.list.component.scss']
})
export class ParametroListComponent {
  srcNumero: string;
  srcReferencia: string;

  dataSource = new MatTableDataSource<Requisicao>();
  // displayedColumns = ['Referencia','Servico','Nota','Operacao', 'Prestador', 'Valor', 'Cidade', 'Etapa'
  //  ,'Tempo','Status','Erro','Observacao'];
    displayedColumns = ['Referencia','Nota', 'Valor', 'Cidade', 'Operacao', 'Etapa','Tempo', 'Observacao'];

  @Input('dataSource')
  set dataSourceForTable(value: Requisicao[]) {
     this.dataSource = new MatTableDataSource<Requisicao>(value);
  }

   @Input() totalCount: number;
   @Output() onDeleteCustomer = new EventEmitter();
   @Output() onPageSwitch = new EventEmitter();

  constructor(private requisicaoOverviewComponent: ParametroOverviewComponent, 
    public paginationService: PaginationService) { }

  onPesquisar(): void{
    if(this.srcNumero == null) this.srcNumero = '';
    if(this.srcReferencia == null) this.srcReferencia = '';

    this.requisicaoOverviewComponent.getAllRequisicao(this.srcNumero, this.srcReferencia);
    //this.dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);;
    // this.usuarioDataService.getAll<RootUsuario[]>(this.srcNome, this.srcLogin)
    // .subscribe((result: any) => {
    //     //this.totalCount = JSON.parse(result.headers.get('X-Pagination')).totalCount;
    //     this.totalCount = result.body.totalRegistros;
    //     //this.dataSource = result.body.value;
    //     this.dataSource = result.body.objeto;
    // });
  }
}
