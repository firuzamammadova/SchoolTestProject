import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Exam } from './models/exam.model';
import { Lesson } from './models/lesson.model';
import { Student } from './models/student.model';
import { ExamResult } from './models/examResult.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private apiUrl = 'https://localhost:7233'; // Replace with your API endpoint

  constructor(private http: HttpClient) {}

  getExams(): Observable<Exam[]> {
    return this.http.get<Exam[]>(`${this.apiUrl}/api/exam`);
  }
  getExamResults(): Observable<ExamResult[]> {
    return this.http.get<ExamResult[]>(`${this.apiUrl}/api/exam/GetExamResults`);
  }

  postExam(data: any): Observable<Exam> {
    return this.http.post<any>(`${this.apiUrl}/api/exam`, data);
  }
  getLessons(): Observable<Lesson[]> {
    return this.http.get<Lesson[]>(`${this.apiUrl}/api/lesson`);
  }
  postLesson(data: any): Observable<Lesson> {
    return this.http.post<Lesson>(`${this.apiUrl}/api/lesson`, data);
  }
  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.apiUrl}/api/student`);
  }
  postStudent(data: any): Observable<Student> {
    return this.http.post<Student>(`${this.apiUrl}/api/student`, data);
  }

  // Add other methods as needed (PUT, DELETE, etc.)
}
