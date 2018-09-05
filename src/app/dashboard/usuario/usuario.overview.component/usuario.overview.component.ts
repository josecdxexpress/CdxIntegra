import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { UsuarioDataService } from '../../../core/service/usuario.data.service';
import { PaginationService } from '../../../core/service/pagination.service';
import { Usuario } from '../../../model/usuario';
import { RootUsuario } from '../../../model/usuario';
import { MatDialog, MatDialogRef } from '@angular/material';
import { ConfirmationDialog } from '../../../core/confirmation.dialog';

@Component({
    selector: 'app-usuario-overview',
    templateUrl: './templates/usuario.overview.component.html'
})

export class UsuarioOverviewComponent implements OnInit {

    dataSource: Usuario[];
    totalCount: number;
    dialogRef: MatDialogRef<ConfirmationDialog>;

    constructor(
        private usuarioDataService: UsuarioDataService,
        private paginationService: PaginationService,
        public dialog: MatDialog) { }

    ngOnInit(): void {
        this.getAllCustomers('','');
    }

    switchPage(event: PageEvent) {
        this.paginationService.change(event);
        this.getAllCustomers('', '');
    }

    delete(customer: Usuario) {
        this.dialogRef = this.dialog.open(ConfirmationDialog, {
            disableClose: false
          });

        this.dialogRef.componentInstance.confirmMessage = "Deseja excluir o usuário " + customer.nome + "?";
        this.dialogRef.afterClosed().subscribe(result => {
            if(result) {

        this.usuarioDataService.fireRequest(customer, 'DELETE')
            .subscribe(() => {
                this.dataSource = this.dataSource.filter(x => x.id !== customer.id);
            });
        }
        this.dialogRef = null;
      });
    }

    // openConfirmationDialog() {
    //     this.dialogRef = this.dialog.open(ConfirmationDialog, {
    //       disableClose: false
    //     });
    //     this.dialogRef.componentInstance.confirmMessage = "Are you sure you want to delete?"
    
    //     this.dialogRef.afterClosed().subscribe(result => {
    //       if(result) {
    //         // do confirmation actions
    //       }
    //       this.dialogRef = null;
    //     });
    //   }
    getSingle(id: number) {
       return this.usuarioDataService.getSingle<Usuario>(id);
            //.subscribe();
    }

    getAllCustomers(nome: string, login: string) {
        this.usuarioDataService.getAll<RootUsuario[]>(nome, login)
            .subscribe((result: any) => {
                //this.totalCount = JSON.parse(result.headers.get('X-Pagination')).totalCount;
                this.totalCount = result.body.totalRegistros;
                //this.dataSource = result.body.value;
                this.dataSource = result.body.objeto;
            });
    }
}
