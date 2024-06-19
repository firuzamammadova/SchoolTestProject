import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ExamFormComponent } from './exam-form/exam-form.component';
import { ExamListComponent } from './exam-list/exam-list.component';
import { HomeComponent } from './home/home.component';
import { LessonFormComponent } from './lesson-form/lesson-form.component';
import { StudentFormComponent } from './student-form/student-form.component';

const routes: Routes = [
  { path: '', component: HomeComponent },

  { path: 'create', component: LessonFormComponent },
  { path: 'createStudent', component: StudentFormComponent },
  { path: 'createExam', component: ExamFormComponent },
  { path: 'examlist', component: ExamListComponent },




];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
