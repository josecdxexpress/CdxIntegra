import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatIconModule, MatCardModule, MatButtonModule, MatListModule, MatProgressBarModule, MatMenuModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

import { DashboardComponent } from './dashboard.component';
import { DashboardRoutes } from './dashboard.routing';
import { RequisicaoComponent } from './requisicao/requisicao.component';
import { RequisicaoOverviewComponent } from './requisicao/requisicao.overview.component/requisicao.overview.component';
import { RequisicaoListComponent } from './requisicao/requisicao.list.component/requisicao.list.component';
import { RequisicaoDataService } from '../core/service/requisicao.data.service'

// import { UsuarioComponent } from './usuario/usuario.component';
// import { UsuarioOverviewComponent } from './usuario/usuario.overview.component/usuario.overview.component';
// import { UsuarioListComponent } from './usuario/usuario.list.component/usuario.list.component';
// import { UsuarioFormComponent } from './usuario/usuario.form.component/usuario.form.component';
// import { UsuarioService } from './usuario/usuario.service'
// import { UsuarioDataService } from '../core/service/usuario.data.service'

// import { CidadeComponent } from './cidade/cidade.component';
// import { CidadeOverviewComponent } from './cidade/cidade.overview.component/cidade.overview.component';
// import { CidadeListComponent } from './cidade/cidade.list.component/cidade.list.component';
// import { CidadeFormComponent } from './cidade/cidade.form.component/cidade.form.component';
// import { CidadeDataService } from '../core/service/cidade.data.service'

// import { PrestadorComponent } from './prestador/prestador.component';
// import { PrestadorOverviewComponent } from './prestador/prestador.overview.component/prestador.overview.component';
// import { PrestadorListComponent } from './prestador/prestador.list.component/prestador.list.component';
// import { PrestadorFormComponent } from './prestador/prestador.form.component/prestador.form.component';
// import { PrestadorDataService } from '../core/service/prestador.data.service'

// import { ParametroComponent } from './parametro/parametro.component';
// import { ParametroOverviewComponent } from './parametro/parametro.overview.component/parametro.overview.component';
// import { ParametroListComponent } from './parametro/parametro.list.component/parametro.list.component';
// import { ParametroFormComponent } from './parametro/parametro.form.component/parametro.form.component';
// import { ParametroDataService } from '../core/service/parametro.data.service'

import { MatDialog, MatSelectModule ,MatInputModule, MatTableModule, MatPaginatorModule, MatSortModule, MatFormFieldModule} from '@angular/material';
import { MatToolbarModule} from '@angular/material/toolbar';
//import {MatMenuModule} from '@angular/material/menu';
//import {MatIconModule} from '@angular/material/icon';
//import { MatSidenavModule} from '@angular/material/sidenav';
//import {MatCardModule} from '@angular/material/card';
//import {MatButtonModule} from '@angular/material/button';
// import { MatTabsModule} from '@angular/material/tabs'; 
// import { MatDividerModule} from '@angular/material/divider';
import { PaginationService } from '../core/service/pagination.service';
// import { ConfirmationDialog } from '../core/confirmation.dialog';
// import { MatDialogModule} from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
//import { RouterModule }  from '@angular/router';
//import { HttpModule }  from '@angular/http';


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(DashboardRoutes),
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatListModule,
    MatProgressBarModule,
    MatMenuModule,
    FlexLayoutModule,
    //CommonModule,
    //FormsModule,
    //ReactiveFormsModule,
    //RouterModule,
    //HttpModule,
    MatFormFieldModule,
    //MatButtonModule,
    //MatToolbarModule,
    //MatCardModule,
    //MatIconModule,
    //MatMenuModule,
    MatTableModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    //MatSidenavModule,
    //MatTabsModule,
    // MatSelectModule,
    // MatDividerModule,
    // MatDialogModule,
    CommonModule,
    FormsModule,
    //ReactiveFormsModule,
    //RouterModule,
    //HttpModule
  ],
  declarations: [ DashboardComponent,
   //CidadeComponent, CidadeOverviewComponent, CidadeListComponent, CidadeFormComponent,
   //UsuarioComponent, UsuarioFormComponent, UsuarioOverviewComponent, UsuarioListComponent,
   //PrestadorComponent, PrestadorOverviewComponent, PrestadorListComponent, PrestadorFormComponent,
   //ParametroComponent, ParametroOverviewComponent, ParametroListComponent, ParametroFormComponent,
   RequisicaoComponent
   , RequisicaoOverviewComponent, RequisicaoListComponent
   //, DashboardComponent
  ],
  providers:[RequisicaoDataService, PaginationService]//CidadeDataService, PrestadorDataService, RequisicaoDataService, ParametroDataService, UsuarioDataService, UsuarioService, PaginationService, MatDialog],

})

export class DashboardModule {}
