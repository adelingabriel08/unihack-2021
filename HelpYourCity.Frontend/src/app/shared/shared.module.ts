import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ProgressBarComponent} from './components/progress-bar/progress-bar.component';
import {ButtonComponent} from './components/button/button.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MenuComponent} from './components/menu/menu.component';
import {MatButtonModule} from '@angular/material/button';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';


@NgModule({
  declarations: [
    ProgressBarComponent,
    ButtonComponent,
    MenuComponent
  ],
  exports: [
    ProgressBarComponent,
    ButtonComponent,
    MenuComponent
  ],
  imports: [
    CommonModule,
    MatProgressBarModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule
  ]
})
export class SharedModule {
}
