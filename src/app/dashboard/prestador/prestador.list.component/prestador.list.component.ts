import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { PrestadorDataService } from '../../../core/service/prestador.data.service';
import { PaginationService } from '../../../core/service/pagination.service';
import { Prestador } from '../../../model/prestador';
import { RootPrestador } from '../../../model/prestador';
import { PrestadorOverviewComponent } from '../prestador.overview.component/prestador.overview.component';
import { MatPaginator, MatTableDataSource, MatFormField, MatFormFieldControl } from '@angular/material';

@Component({
  selector: 'app-prestador-lista',
  templateUrl: './templates/prestador.list.component.html',
  styleUrls: ['./templates/prestador.list.component.scss']
})
export class PrestadorListComponent {
  srcNumero: string;
  srcReferencia: string;

  dataSource = new MatTableDataSource<Prestador>();
  // displayedColumns = ['Referencia','Servico','Nota','Operacao', 'Prestador', 'Valor', 'Cidade', 'Etapa'
  //  ,'Tempo','Status','Erro','Observacao'];
    displayedColumns = ['Referencia','Nota', 'Valor', 'Cidade', 'Operacao', 'Etapa','Tempo', 'Observacao'];

  @Input('dataSource')
  set dataSourceForTable(value: Prestador[]) {
     this.dataSource = new MatTableDataSource<Prestador>(value);
  }

   @Input() totalCount: number;
   @Output() onDeleteCustomer = new EventEmitter();
   @Output() onPageSwitch = new EventEmitter();

  constructor(private requisicaoOverviewComponent: PrestadorOverviewComponent, 
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
