import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-personal-information-form',
  templateUrl: './personal-information-form.component.html',
  styleUrls: ['./personal-information-form.component.scss']
})
export class PersonalInformationFormComponent {
  // form: FormGroup = this._formBuilder.group({
  //   email: ['', [Validators.required, Validators.email]],
  //   phone: ['', [Validators.required]],
  //   firstName: ['', [Validators.required]],
  //   lastName: ['', [Validators.required]],
  //   companyName: [''],
  // });

  constructor(
    private readonly _formBuilder: FormBuilder
  ) { }
}
