import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription, Observable } from 'rxjs';

import { UsuarioService } from '../usuario.service';
import { Usuario } from '../../../model/usuario';
import { RetornoUsuario } from '../../../model/usuario';
import { BasicValidators } from '../../../shared/basic-validators';
import { ComponentCanDeactivate } from '../usuario-form.guard/usuario-form.guard';
import { MatFormFieldModule, MatButtonModule, MatToolbarModule, MatCardModule, MatIconModule, MatMenuModule } from '@angular/material';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
//import { Component } from '@angular/core';
//import { UsuarioOverviewComponent } from './usuario.overview.component';
import { UsuarioDataService } from '../../../core/service/usuario-data.service';

@Component({
  selector: 'app-usuario-form',
  templateUrl: './templates/usuario-form.component.html',
  styleUrls: ['./templates/usuario-form.component.scss']
})
export class UsuarioFormComponent implements OnInit, OnDestroy, ComponentCanDeactivate {

  form: FormGroup;
  private usuarioIndex: number;
  private title: string;
  private isNew: boolean = true;
  private usuario: Usuario;
  private subscription: Subscription;
  private color: string;
 
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private usuarioService: UsuarioService,
    //private suarioOverviewComponent: UsuarioOverviewComponent,
    private usuarioDataService: UsuarioDataService) { }

  ngOnInit() {
    this.color = "red";
    this.subscription = this.route.params.subscribe(
      (params: any) => {
        if (params.hasOwnProperty('id')) {
          this.isNew = false;
          this.usuarioIndex = +params['id'];
          this.usuario = new Usuario();
          //this.usuarioService.getAll(usuarioValue);
          //this.usuarioDataService.fireRequest(usuarioValue, 'PUT')
          //this.suarioOverviewComponent.getSingle(this.usuarioIndex)
          this.usuarioDataService.getSingle<RetornoUsuario>(this.usuarioIndex)
          .subscribe(data => this.usuario = data.objeto);
          this.title = 'Editar usuário';
        } else {
          this.isNew = true;
          this.usuario = new Usuario();
          // this.usuario.nome = '';
          // this.usuario.login = '';
          // this.usuario.senha = '';
          // this.usuario.email = '';
          this.usuario.situacao = '1';
          this.title = 'Novo usuário';
        }
        this.initForm();
      }
    );
  }

  private initForm() {
    this.form = this.formBuilder.group({
      id: ['', [
      ]],
      nome: ['', [
        Validators.required,
        Validators.minLength(3)
      ]],
      login: ['', [
        Validators.required,
        Validators.minLength(3)
      ]],
      senha: ['', [
        Validators.required,
        Validators.minLength(3)
      ]],
      email: ['', [
        Validators.required,
        BasicValidators.email,
        Validators.pattern("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")
      ]]//,
      //phone: this.formBuilder.group({
      //  phoneNumber: []
      //})
    });
  }

  onCancel() {
    this.navigateBack();
  }

  private navigateBack() {
    this.router.navigate(['/usuarios']);
  }

  onSave() {
    const usuarioValue = this.form.value;
    let result;

    if (this.isNew){
      //result = this.usuarioService.update(usuarioValue);
      result = this.usuarioService.add(usuarioValue);
    } else {
      //return this.usuarioDataService.update<Usuario>(usuarioValue);
      return this.usuarioDataService.fireRequest(usuarioValue, 'PUT')
      .subscribe(value => {
            this.router.navigateByUrl('/usuarios');
        }
    );
      //this.router.navigate(['usuarios']);
    }

    this.form.reset();

    result.subscribe(data => this.navigateBack(),
    err => {
      alert("An error occurred.");
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  canDeactivate(): Observable<boolean> | boolean {
    if (this.form.dirty) {
      return confirm('Do you want to leave this page?');
    }
    return true;
  }
}
