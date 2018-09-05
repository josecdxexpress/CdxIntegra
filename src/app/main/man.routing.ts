import { Routes, RouterModule } from '@angular/router';
///import { UsuarioComponent } from './usuario/usuario.component';
//import { UsuarioFormComponent } from './usuario/usuario-form.component/usuario-form.component';
//import { UsuarioFormGuard } from './usuario/usuario-form.guard/usuario-form.guard';
//import { RequisicaoComponent } from './requisicao/requisicao.component';

const MAIN_ROUTES: Routes = [
  // { path: 'usuarios', component: UsuarioComponent },
  // { path: 'usuarios/novo', component: UsuarioFormComponent },
  // { path: 'usuarios/editar/:id', component: UsuarioFormComponent },
  // //{ path: 'requisicoes', component: RequisicaoComponent }
  //,
  //{ path: 'parametros', component: ParametroComponent },
  //{ path: 'parametros/novo', component: ParametroFormComponent },
  //{ path: 'parametros/editar/:id', component: ParametroFormComponent }
];

export const UsuarioRouting = RouterModule.forChild(MAIN_ROUTES);
