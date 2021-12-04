import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-personal-information-form',
  templateUrl: './personal-information-form.component.html',
  styleUrls: ['./personal-information-form.component.scss']
})
export class PersonalInformationFormComponent {
  form: FormGroup = this._formBuilder.group({
    email: [null, [Validators.required, Validators.email]],
    phone: [null, [Validators.required]],
    firstName: [null, [Validators.required]],
    lastName: [null, [Validators.required]],
    companyName: [null],
  });

  constructor(
    private readonly _formBuilder: FormBuilder
  ) {
  }
}
