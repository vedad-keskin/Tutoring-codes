import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  StudentGetByIdEndpointService, StudentGetByIdResponse
} from '../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../shared/snackbars/my-snackbar-helper.service';
import {
  SemesterGetByStudentIdEndpoint
} from '../../../../endpoints/semester-endpoint/semester-get-student-by-id-endpoint.service';

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
                  private semesterGetByStudentIdService:SemesterGetByStudentIdEndpoint

                  ) {

    this.studentId = route.snapshot.params['id'];


  }

  ngOnInit(): void {

    this.getByIdStudent();
    this.fetchSemesters();

    }


  private getByIdStudent() {

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

  private fetchSemesters() {


    this.semesterGetByStudentIdService.handleAsync(this.studentId).subscribe({
      next: (data) => {

        this.semesters = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error getting semesters. Please try again.', 5000);
        console.error('Error getting semesters:', err);
      }
    });

  }

  navigateToNewSemster() {

    this.router.navigate(['/admin/students/semesters/new', this.studentId]);


  }
}
