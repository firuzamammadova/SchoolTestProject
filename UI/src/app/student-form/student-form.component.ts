import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent  {

  student = {

    name: '',
    surname: '',
    class: null,
  };

  constructor(private apiService: ApiService, private router: Router) {}

  async onSubmit() {
    console.log(this.student);

    const newStudent = {
      ...this.student,
    };

    try {
      await this.apiService.postStudent(newStudent).toPromise();
      // this.router.navigate(['/']);
    } catch (error) {
      console.error('Error adding movie:', error);
      // Handle the error appropriately
    }
  }
}
