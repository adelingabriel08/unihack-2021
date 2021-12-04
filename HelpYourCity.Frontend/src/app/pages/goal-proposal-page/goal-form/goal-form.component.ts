import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ProposalService} from '../../../services/proposal.service';
import {IFileResponse} from '../../../models/file-response.model';

@Component({
  selector: 'app-goal-form',
  templateUrl: './goal-form.component.html',
  styleUrls: ['./goal-form.component.scss']
})
export class GoalFormComponent {
  responseFile: IFileResponse | undefined;
  form: FormGroup = this._formBuilder.group({
    title: [null, [Validators.required]],
    imageId: [null, [Validators.required]],
    shortDescription: ['', [Validators.required]],
    description: [null, [Validators.required]],
    target: [null, [Validators.required]],
    pricePerUnit: [null, [Validators.required]],
    goalItemName: [null, [Validators.required]]
  });

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _proposalService: ProposalService
  ) { }

  async fileChange(e: any): Promise<void> {
    const {files} = e.target;
    if (files.length !== 1) {
        return;
    }
    const file: File = files[0];
    this.responseFile = await this._proposalService.uploadFile(file).toPromise();
    this.form.controls['imageId'].setValue(this.responseFile?.id);
  }
}
