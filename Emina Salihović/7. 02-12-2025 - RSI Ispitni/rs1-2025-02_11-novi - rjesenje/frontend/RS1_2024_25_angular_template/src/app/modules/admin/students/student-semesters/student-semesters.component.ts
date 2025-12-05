import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  StudentGetByIdEndpointService
} from '../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../shared/snackbars/my-snackbar-helper.service';

@Component({
  selector: 'app-student-semesters',
  standalone: false,

  templateUrl: './student-semesters.component.html',
  styleUrl: './student-semesters.component.css'
})
export class StudentSemestersComponent implements OnInit {


  studentId: number = 0;
  student:any;

constructor(  private route: ActivatedRoute,
              private router: Router,
              private studentGetByIdService:StudentGetByIdEndpointService,
              private snackbar: MySnackbarHelperService,
              ) {

  this.studentId = route.snapshot.params['id'];

}

  ngOnInit(): void {

  this.GetStudent();

    }


  private GetStudent() {

    this.studentGetByIdService.handleAsync(this.studentId).subscribe({
      next: (data) => {
        this.snackbar.showMessage('Student successfully fetched.');

        this.student = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching student. Please try again.', 5000);
        console.error('Error fetching student:', err);
      }
    });


  }
}
