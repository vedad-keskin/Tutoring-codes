import { Component } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-student-semesters',
  standalone: false,

  templateUrl: './student-semesters.component.html',
  styleUrl: './student-semesters.component.css'
})
export class StudentSemestersComponent {


  // Nase varijable
  studentId: number = 0;


  constructor(
    private route: ActivatedRoute,
    private router: Router,

  ) {

    this.studentId = this.route.snapshot.params['id'];

  }


}
