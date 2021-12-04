import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ProgressBarComponent} from './components/progress-bar/progress-bar.component';
import {ButtonComponent} from './components/button/button.component';


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
    CommonModule
  ]
})
export class SharedModule {
}
