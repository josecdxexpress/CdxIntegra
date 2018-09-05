import { Routes } from '@angular/router';

import { DashboardComponent } from './dashboard.component';

import { RequisicaoComponent } from './requisicao/requisicao.component';
// import { ParametroComponent } from './parametro/parametro.component';
// import { UsuarioComponent } from './usuario/usuario.component';
// import { CidadeComponent } from './cidade/cidade.component';
// import { PrestadorComponent } from './prestador/prestador.component';

export const DashboardRoutes: Routes = [{
  path: '',
  component: DashboardComponent
}
,  { path: 'requisicoes', component: RequisicaoComponent },
//     { path: 'parametros', component: ParametroComponent },
//     { path: 'usuarios', component: UsuarioComponent },
//     { path: 'cidades', component: CidadeComponent },
//     { path: 'prestadores', component: PrestadorComponent }
];
