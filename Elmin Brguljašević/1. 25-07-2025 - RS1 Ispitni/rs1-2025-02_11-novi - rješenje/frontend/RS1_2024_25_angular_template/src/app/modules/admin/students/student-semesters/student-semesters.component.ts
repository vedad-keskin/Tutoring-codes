import {Component, Inject, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  StudentGetByIdEndpointService, StudentGetByIdResponse
} from '../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../shared/snackbars/my-snackbar-helper.service';
import {
  SemesterGetAllByStudentIdEndpoint
} from '../../../../endpoints/semester-endpoints/semester-get-all-by-student-id-endpoint.service';

@Component({
  selector: 'app-student-semesters',
  standalone: false,

  templateUrl: './student-semesters.component.html',
  styleUrl: './student-semesters.component.css'
})
export class StudentSemestersComponent implements OnInit {

  studentId: number = 0;
  //student:any;
  student: StudentGetByIdResponse | null = null;
  semesters:any;
  displayedColumns: string[] = ['id', 'academicYear', 'yearOfStudy', 'renewal','winterSemester','recordedBy'];


  constructor(    private route: ActivatedRoute,
                  private router: Router,
                  private studentGetByIdService:StudentGetByIdEndpointService,
                  private snackbar: MySnackbarHelperService,
                  private semesterGetAllByStudentIdService:SemesterGetAllByStudentIdEndpoint
                  ) {

    this.studentId = this.route.snapshot.params['id'];

  }

  ngOnInit(): void {

    this.fetchStudent();
    this.fetchSemesters();

    }


  private fetchStudent() {

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

  private fetchSemesters() {

    this.semesterGetAllByStudentIdService.handleAsync(this.studentId).subscribe({
      next: (data) => {
        this.snackbar.showMessage('Semesters successfully fetched.');

        this.semesters = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching semesters. Please try again.', 5000);
        console.error('Error fetching semesters:', err);
      }
    });

  }
}
