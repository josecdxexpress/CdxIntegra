import { UsuarioService } from '../usuario.service';
import { Usuario } from '../../../model/usuario';
import { RootUsuario } from '../../../model/usuario';
import { MatPaginator, MatTableDataSource, MatFormField, MatFormFieldControl } from '@angular/material';
import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { PaginationService } from '../../../core/service/pagination.service';
//import { UsuarioDataService } from '../../../core/service/usuario-data.service';
import { UsuarioOverviewComponent } from '../usuario.overview.component/usuario.overview.component';

// export interface PeriodicElement {
//   name: string;
//   position: number;
//   weight: number;
//   symbol: string;
// }

// const ELEMENT_DATA: PeriodicElement[] = [
//   {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
//   {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
//   {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
//   {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
//   {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
//   {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
//   {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
//   {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
//   {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
//   {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
// ];

@Component({
  selector: 'app-usuario-list',
  templateUrl: './templates/usuario-list.component.html',
  styleUrls: ['./templates/usuario-list.component.scss']
})
export class UsuarioListComponent {

  // @ViewChild(MatPaginator) paginator: MatPaginator;

  // usuarios: Usuario[] = [];
  srcNome: string;
  srcLogin: string;

  // rootusuario : RootUsuario; 

  // displayedColumns: string[] = ['Codigo', 'Nome', 'Login', 'Email', 'Situacao', 'actionsColumn'];
  //dataSource: Usuario[] = [];

  dataSource = new MatTableDataSource<Usuario>();
  displayedColumns = ['Codigo', 'Nome', 'Login', 'Email', 'Situacao', 'actionsColumn'];

  @Input('dataSource')
  set dataSourceForTable(value: Usuario[]) {
      this.dataSource = new MatTableDataSource<Usuario>(value);
  }
 
  @Input() totalCount: number;
  @Output() onDeleteCustomer = new EventEmitter();
  @Output() onPageSwitch = new EventEmitter();

  constructor(private usuarioOverviewComponent: UsuarioOverviewComponent, 
    public paginationService: PaginationService) { }

  //ngOnInit() {
    //this.usuarioService.listar().subscribe(dados => this.usuarios = dados.objeto);


    // var dataSource = new MatTableDataSource<Usuario>(this.usuarios);

    // dataSource.paginator = this.paginator;

    // this.usuarioService.usuarioChanged.subscribe(
    //   (observable: any) => observable.subscribe(
    //     data => this.usuarios = data
    //   )
    // );
  //}

  onPesquisar(): void{
    if(this.srcNome == null) this.srcNome = '';
    if(this.srcLogin == null) this.srcLogin = '';

    this.usuarioOverviewComponent.getAllCustomers(this.srcNome, this.srcLogin);

    // this.usuarioDataService.getAll<RootUsuario[]>(this.srcNome, this.srcLogin)
    // .subscribe((result: any) => {
    //     //this.totalCount = JSON.parse(result.headers.get('X-Pagination')).totalCount;
    //     this.totalCount = result.body.totalRegistros;
    //     //this.dataSource = result.body.value;
    //     this.dataSource = result.body.objeto;
    // });
  }
}
