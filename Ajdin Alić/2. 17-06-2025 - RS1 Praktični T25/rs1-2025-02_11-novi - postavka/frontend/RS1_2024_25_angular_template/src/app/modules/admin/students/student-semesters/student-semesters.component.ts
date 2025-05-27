import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  StudentGetByIdEndpointService, StudentGetByIdResponse
} from '../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../shared/snackbars/my-snackbar-helper.service';
import {
  SemesterGetByStudentIdEndpoint
} from '../../../../endpoints/semester-endpoints/semester-get-by-student-id-endpoint.service';

@Component({
  selector: 'app-student-semesters',
  standalone: false,

  templateUrl: './student-semesters.component.html',
  styleUrl: './student-semesters.component.css'
})
export class StudentSemestersComponent implements OnInit {

  // Nase varijable

  studentId: any;
  //student:any;
  student: StudentGetByIdResponse | null = null;
  displayedColumns: string[] = ['id', 'academicYear', 'yearOfStudy', 'renewal','dateOnEnrollment','recordedBy'];
  semesters:any;


  constructor( private route: ActivatedRoute,
               private router: Router,
               private studentGetByIdService:StudentGetByIdEndpointService,
               private snackbar: MySnackbarHelperService,
               private semesterGetByStudentIdService:SemesterGetByStudentIdEndpoint
               ) {

    this.studentId = this.route.snapshot.params['id'];

  }

  ngOnInit(): void {

    this.fetchStudent();
    this.fetchSemesters();

    }


  private fetchStudent() {

    this.studentGetByIdService.handleAsync(this.studentId).subscribe({
      next: ( data ) => {

        this.student = data;


      },
      error: (err) => {
        this.snackbar.showMessage('Error restoring student. Please try again.', 5000);
        console.error('Error restoring student:', err);
      }
    });


  }

  private fetchSemesters() {

    this.semesterGetByStudentIdService.handleAsync(this.studentId).subscribe({
      next: ( data ) => {

        this.semesters = data;


      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching semesters. Please try again.', 5000);
        console.error('Error fetching semesters: ', err);
      }
    });


  }

  goToNewSemester() {

    this.router.navigate(['/admin/students/semesters/new', this.studentId]);

  }
}
