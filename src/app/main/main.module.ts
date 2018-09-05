import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {BrowserModule} from '@angular/platform-browser';
import {Component} from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule }  from '@angular/router';
import { HttpModule }  from '@angular/http';
import { FormGroup, FormControl } from '@angular/forms';
//import { UsuarioComponent } from '../dashboard/usuario/usuario.component';
//import { UsuarioListComponent } from '../dashboard/usuario/usuario.list.component/usuario.list.component';
//import { UsuarioFormComponent } from '../dashboard/usuario/usuario.form.component/usuario.form.component';
//import { UsuarioService } from '../dashboard/usuario/usuario.service';
//import { UsuarioFormGuard } from '../dashboard/usuario/usuario.form.guard/usuario-form.guard';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { MatDialog, MatSelectModule ,MatInputModule, MatTableModule, MatPaginatorModule, MatSortModule, MatFormFieldModule} from '@angular/material';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatTabsModule} from '@angular/material/tabs'; 
import {MatDividerModule} from '@angular/material/divider';
// import { UsuarioOverviewComponent } from '../dashboard/usuario/usuario.overview.component/usuario.overview.component'
// import { UsuarioDataService } from '../core/service/usuario.data.service'
// import { RequisicaoDataService } from '../../app/core/service/requisicao.data.service'
// import { CidadeDataService } from '../../app/core/service/cidade.data.service'
// import { PrestadorDataService } from '../../app/core/service/prestador.data.service'
// import { PaginationService } from '../core/service/pagination.service';
// import { ConfirmationDialog } from '../core/confirmation.dialog';
// import { MatDialogModule} from '@angular/material';

// import { DashboardComponent } from '../dashboard/dashboard.component';
// import { RequisicaoComponent } from '../dashboard/requisicao/requisicao.component';
// import { RequisicaoListComponent } from '../dashboard/requisicao/requisicao.list.component/requisicao.list.component';
// import { RequisicaoOverviewComponent } from '../dashboard/requisicao/requisicao.overview.component/requisicao.overview.component';

// import { ParametroComponent } from '../dashboard/parametro/parametro.component';
// import { ParametroListComponent } from '../dashboard/parametro/parametro.list.component/parametro.list.component';
// import { ParametroFormComponent } from '../dashboard/parametro/parametro.form.component/parametro.form.component';
// import { ParametroOverviewComponent } from '../dashboard/parametro/parametro.overview.component/parametro.overview.component';
// import { ParametroDataService } from '../core/service/parametro.data.service'

// import { CidadeComponent } from '../dashboard/cidade/cidade.component';
// import { CidadeListComponent } from '../dashboard/cidade/cidade.list.component/cidade.list.component';
// import { CidadeFormComponent } from '../dashboard/cidade/cidade.form.component/cidade.form.component';
// import { CidadeOverviewComponent } from '../dashboard/cidade/cidade.overview.component/cidade.overview.component';

// import { PrestadorComponent } from '../dashboard/prestador/prestador.component';
// import { PrestadorListComponent } from '../dashboard/prestador/prestador.list.component/prestador.list.component';
// import { PrestadorFormComponent } from '../dashboard/prestador/prestador.form.component/prestador.form.component';
// import { PrestadorOverviewComponent } from '../dashboard/prestador/prestador.overview.component/prestador.overview.component';

@NgModule({
    imports: [
      CommonModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule,
      HttpModule,
      MatFormFieldModule,
      MatButtonModule,
      MatToolbarModule,
      MatCardModule,
      MatIconModule,
      MatMenuModule,
      MatTableModule,
      MatInputModule,
      MatTableModule,
      MatPaginatorModule,
      MatSortModule,
      MatSidenavModule,
      MatTabsModule,
      MatSelectModule,
      MatDividerModule,
      //MatDialogModule,
      CommonModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule,
      HttpModule,
    ],
    declarations: [
        // UsuarioOverviewComponent,
        // UsuarioComponent,
        // UsuarioListComponent,
        // UsuarioFormComponent,
        // ConfirmationDialog//,
        // RequisicaoOverviewComponent,
        // RequisicaoComponent,
        // RequisicaoListComponent,
        // ParametroOverviewComponent,
        // ParametroComponent,
        // ParametroListComponent,
        // ParametroFormComponent
        
    ],
    providers:[],//CidadeDataService, PrestadorDataService, RequisicaoDataService, ParametroDataService, UsuarioDataService, UsuarioService, PaginationService, MatDialog],
    entryComponents: [],//[ConfirmationDialog]
    //providers: [ UsuarioService, UsuarioFormGuard ]
    //,schemas: [ NO_ERRORS_SCHEMA ],
})
export class MainModule {}
