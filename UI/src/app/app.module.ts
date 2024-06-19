import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { LessonFormComponent } from './lesson-form/lesson-form.component';
import { ApiService } from './api.service';
import { ExamListComponent } from './exam-list/exam-list.component';
import { StudentFormComponent } from './student-form/student-form.component';
import { ExamFormComponent } from './exam-form/exam-form.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    LessonFormComponent,
    ExamListComponent,
    StudentFormComponent,
    ExamFormComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,

  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
