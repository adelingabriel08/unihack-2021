import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {HttpClientModule} from '@angular/common/http';
import { GoalDetailsPageComponent } from './pages/goal-details-page/goal-details-page.component';
import {MatCardModule} from '@angular/material/card';
import { ContributionComponent } from './pages/goal-details-page/contribution/contribution.component';
import {SharedModule} from './shared/shared.module';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { GoalEventsPageComponent } from './pages/goal-events-page/goal-events-page.component';
import { EventCardComponent } from './pages/goal-events-page/event-card/event-card.component';
import { EventApplicationFormComponent } from './pages/goal-events-page/event-application-form/event-application-form.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule} from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    GoalDetailsPageComponent,
    ContributionComponent,
    GoalEventsPageComponent,
    EventCardComponent,
    EventApplicationFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule,
    SharedModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatProgressSpinnerModule,
    MatDialogModule,
    MatSnackBarModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
