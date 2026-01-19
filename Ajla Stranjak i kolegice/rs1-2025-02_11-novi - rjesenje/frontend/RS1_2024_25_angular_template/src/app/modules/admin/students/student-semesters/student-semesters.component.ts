import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  StudentGetByIdEndpointService, StudentGetByIdResponse
} from '../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../shared/snackbars/my-snackbar-helper.service';

@Component({
  selector: 'app-student-semesters',
  standalone: false,

  templateUrl: './student-semesters.component.html',
  styleUrl: './student-semesters.component.css'
})
export class StudentSemestersComponent implements OnInit {


  // Nase varijable

  studentId:number = 0;
  //studentId:any;
  //student:any;
    student: StudentGetByIdResponse | null = null;

  constructor(   private route: ActivatedRoute,
                 private router: Router,
                 private studentGetByIdService:StudentGetByIdEndpointService,
                 private snackbar: MySnackbarHelperService,

  ) {

    this.studentId = this.route.snapshot.params['id'];

  }

  ngOnInit(): void {

     this.GetByIdStudent();

    }


  private GetByIdStudent() {


    this.studentGetByIdService.handleAsync(this.studentId).subscribe({
      next: (data) => {

      this.student = data;


      },
      error: (err) => {
        this.snackbar.showMessage('Error getting student. Please try again.', 5000);
        console.error('Error getting student:', err);
      }
    });

  }
}
