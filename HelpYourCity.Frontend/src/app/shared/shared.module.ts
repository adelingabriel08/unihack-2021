import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ProgressBarComponent} from './components/progress-bar/progress-bar.component';
import {ButtonComponent} from './components/button/button.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatProgressBarModule} from '@angular/material/progress-bar';


@NgModule({
  declarations: [
    ProgressBarComponent,
    ButtonComponent
  ],
  exports: [
    ProgressBarComponent,
    ButtonComponent
  ],
  imports: [
    CommonModule,
    MatProgressBarModule
  ]
})
export class SharedModule {
}
