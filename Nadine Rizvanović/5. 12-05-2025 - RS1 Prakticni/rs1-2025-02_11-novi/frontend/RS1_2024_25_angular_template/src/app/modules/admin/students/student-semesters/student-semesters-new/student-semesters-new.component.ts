import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {
  StudentGetByIdEndpointService,
  StudentGetByIdResponse
} from '../../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../../shared/snackbars/my-snackbar-helper.service';

@Component({
  selector: 'app-student-semesters-new',
  standalone: false,

  templateUrl: './student-semesters-new.component.html',
  styleUrl: './student-semesters-new.component.css'
})
export class StudentSemestersNewComponent implements OnInit {


  // Nase globalne varijable
  studentId:number=0;
  student: StudentGetByIdResponse | null = null;


  constructor(
    private route: ActivatedRoute,
    private studentGetByIdService:StudentGetByIdEndpointService,
    private snackbar: MySnackbarHelperService,
  ) {
    this.studentId = this.route.snapshot.params['id'];

  }

  ngOnInit(): void {
    this.fetchStudent();

  }


  private fetchStudent() {
    this.studentGetByIdService.handleAsync(this.studentId).subscribe({
      next: (data) => {

        this.student = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching student. Please try again.', 5000);
        console.error('Error fetching student:', err);
      }
    });
  }
}
