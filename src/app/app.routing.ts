import { Routes } from '@angular/router';

import { AdminLayoutComponent, AuthLayoutComponent } from './core';

//import { UsuarioComponent } from '../app/main/usuario/usuario.component';
//import { RequisicaoComponent } from '../app/main/requisicao/requisicao.component';
//import { UsuarioFormComponent } from '../app/main/usuario/usuario-form.component/usuario-form.component';
//import { ParametroComponent } from '../app/main/parametro/parametro.component';
//import { ParametroFormComponent } from '../app/main/parametro/parametro.form.component/parametro.form.component';


export const AppRoutes: Routes = [{
  path: '',
  component: AdminLayoutComponent,
  children: [{
    path: '',
    loadChildren: './dashboard/dashboard.module#DashboardModule'
  }]
}, 
// {
//   path: '',
//   component: UsuarioComponent,
//   children: [{
//     path: 'usuarios',
//     loadChildren: './main/main.module#MainModule'
//   }]
// },
{
  path: '',
  component: AuthLayoutComponent,
  children: [{
    path: 'session',
    loadChildren: './session/session.module#SessionModule'
  }]
}, {
  path: '**',
  redirectTo: 'session/404'
}
// , 
// { path: 'usuarios', component: UsuarioComponent },
// { path: 'usuarios/novo', component: UsuarioFormComponent },
// { path: 'usuarios/editar/:id', component: UsuarioFormComponent },
// { path: 'requisicoes', component: RequisicaoComponent },
// { path: 'parametros', component: ParametroComponent },
// { path: 'parametros/novo', component: ParametroFormComponent },
// { path: 'parametros/editar/:id', component: ParametroFormComponent }
];
