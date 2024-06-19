import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-exam-form',
  templateUrl: './exam-form.component.html',
  styleUrls: ['./exam-form.component.css']
})
export class ExamFormComponent  {


  exam = {
     lessonId: '',
    studentId:null,

     date: new Date(),
     mark: null,
   };
 
   constructor(private apiService: ApiService, private router: Router) {}
 
   async onSubmit() {
 
     const newExam= {
       ...this.exam,
       date: new Date(this.exam.date)

     };
 
     try {
       await this.apiService.postExam(newExam).toPromise();
       // this.router.navigate(['/']);
     } catch (error) {
       console.error('Error adding movie:', error);
       // Handle the error appropriately
     }
   }
}
