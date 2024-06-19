import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Exam } from '../models/exam.model';
import { ExamResult } from '../models/examResult.model';
import { Lesson } from '../models/lesson.model';
import { Student } from '../models/student.model';

@Component({
  selector: 'app-exam-list',
  templateUrl: './exam-list.component.html',
  styleUrls: ['./exam-list.component.css'],
})
export class ExamListComponent implements OnInit {
  title = 'SchoolProjectUI';
  exams: ExamResult[] = [];

  filter = {
    lessonId: '',
    studentId: null,
  };
  //*ngIf="responseData"
  constructor(private apiService: ApiService) {}
  filterExams() {
    this.exams = this.exams.filter(
      (x) =>
        (this.filter.lessonId == '' || x.lessonId == this.filter.lessonId) &&
        (this.filter.studentId == null || x.studentId == this.filter.studentId)
    );

  }
  async ngOnInit(): Promise<void> {
    try {
      this.exams = await this.apiService.getExamResults().toPromise();

      console.log('API Response:', this.exams);
    } catch (error) {
      console.error('API Error:', error);
      // Handle error as needed
    }
  }
}
