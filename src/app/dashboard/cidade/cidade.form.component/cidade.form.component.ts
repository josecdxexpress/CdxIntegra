import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription, Observable } from 'rxjs';

//import { UsuarioService } from '../usuario.service';
import { Cidade } from '../../../model/cidade';
import { RetornoCidade } from '../../../model/cidade';
import { BasicValidators } from '../../../shared/basic-validators';
//import { ComponentCanDeactivate } from '../usuario-form.guard/usuario-form.guard';
import { MatFormFieldModule, MatButtonModule, MatToolbarModule, MatCardModule, MatIconModule, MatMenuModule } from '@angular/material';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
//import { Component } from '@angular/core';
//import { UsuarioOverviewComponent } from './usuario.overview.component';
import { CidadeDataService } from '../../../core/service/cidade.data.service';

@Component({
  selector: 'app-cidade-form',
  templateUrl: './templates/cidade.form.component.html',
  styleUrls: ['./templates/cidade.form.component.scss']
})
export class CidadeFormComponent implements OnInit, OnDestroy {

  form: FormGroup;
  private cidadeIndex: number;
  private title: string;
  private isNew: boolean = true;
  private cidade: Cidade;
  private subscription: Subscription;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    //private usuarioService: UsuarioService,
    //private suarioOverviewComponent: UsuarioOverviewComponent,
    private cidadeDataService: CidadeDataService) { }

  ngOnInit() {
    this.subscription = this.route.params.subscribe(
      (params: any) => {
        if (params.hasOwnProperty('id')) {
          this.isNew = false;
          this.cidadeIndex = +params['id'];
          this.cidade = new Cidade();
          //this.usuarioDataService.getSingle<RetornoParametro>(this.usuarioIndex)
          //.subscribe(data => this.usuario = data.objeto);
          this.title = 'Editar usuário';
        } else {
          this.isNew = true;
          this.cidade = new Cidade();
          this.cidade.situacao = '1';
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
    this.router.navigate(['/cidades']);
  }

  onSave() {
    const cidadeValue = this.form.value;
    let result;

    if (this.isNew){
      //result = this.usuarioService.add(usuarioValue);
    } else {
      // return this.cidadeDataService.fireRequest(usuarioValue, 'PUT')
      // .subscribe(value => {
      //       this.router.navigateByUrl('/cidades');
      //   }
    //);
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
