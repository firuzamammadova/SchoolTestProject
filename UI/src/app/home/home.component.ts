import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Exam } from '../models/exam.model';
import { Lesson } from '../models/lesson.model';
import { Student } from '../models/student.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  title = 'SchoolProjectUI';
  exams: Exam[]=[];
  lessons: Lesson[]=[];
  students: Student[]=[];

  constructor(private apiService: ApiService) { }

  async ngOnInit(): Promise<void> {
    try {
      this.exams = await this.apiService.getExams().toPromise();
      this.lessons = await this.apiService.getLessons().toPromise();
      this.students = await this.apiService.getStudents().toPromise();

      console.log('API Response:', this.exams);
    } catch (error) {
      console.error('API Error:', error);
      // Handle error as needed
    }
  }


}
