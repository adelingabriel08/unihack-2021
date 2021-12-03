import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProgressBarComponent } from './components/progress-bar/progress-bar.component';



@NgModule({
    declarations: [
        ProgressBarComponent
    ],
    exports: [
        ProgressBarComponent
    ],
    imports: [
        CommonModule
    ]
})
export class SharedModule { }
