import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-lesson-form',
  templateUrl: './lesson-form.component.html',
  styleUrls: ['./lesson-form.component.css'],
})
export class LessonFormComponent {
  lesson = {
    lessonId:'',
    lessonName: '',
    class: null,
    teacherName: '',
    teacherSurname: '',
  };

  constructor(private apiService: ApiService, private router: Router) {}

  async onSubmit() {
    console.log(this.lesson);

    const newLesson = {
      ...this.lesson,
    };

    try {
      await this.apiService.postLesson(newLesson).toPromise();
      // this.router.navigate(['/']);
    } catch (error) {
      console.error('Error adding movie:', error);
      // Handle the error appropriately
    }
  }
}
