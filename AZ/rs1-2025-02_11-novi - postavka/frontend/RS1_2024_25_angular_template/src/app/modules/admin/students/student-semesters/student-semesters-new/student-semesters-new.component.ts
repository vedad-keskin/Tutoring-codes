import {Component, OnInit} from '@angular/core';
import {
  StudentGetByIdEndpointService,
  StudentGetByIdResponse
} from '../../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {ActivatedRoute, Router} from '@angular/router';
import {MySnackbarHelperService} from '../../../../shared/snackbars/my-snackbar-helper.service';
import {
  SemesterGetByStudentIdEndpoint
} from '../../../../../endpoints/semester-endpoint/semester-get-student-by-id-endpoint.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MyAuthService} from '../../../../../services/auth-services/my-auth.service';

@Component({
  selector: 'app-student-semesters-new',
  standalone: false,

  templateUrl: './student-semesters-new.component.html',
  styleUrl: './student-semesters-new.component.css'
})
export class StudentSemestersNewComponent implements OnInit {


  studentId: number = 0;
  //student:any;
  student: StudentGetByIdResponse | null = null;
  semesters:any;


  semesterForm: FormGroup;




  constructor(    private route: ActivatedRoute,
                  private router: Router,
                  private studentGetByIdService:StudentGetByIdEndpointService,
                  private snackbar: MySnackbarHelperService,
                  private semesterGetByStudentIdService:SemesterGetByStudentIdEndpoint,
                  private fb: FormBuilder,
                  private myAuthService:MyAuthService

  ) {

    this.studentId = route.snapshot.params['id'];

    this.semesterForm = this.fb.group({

      winterSemester: [new Date(), [Validators.required]],
      yearOfStudy: [null, [Validators.required]],
      price: [null, [Validators.required, Validators.min(50), Validators.max(2000)]],
      renewal: [false, [Validators.required]],
      academicYearId: [1, [Validators.required]],
      studentId: [this.studentId, [Validators.required]],
      recordedById: [myAuthService.getMyAuthInfo()?.userId, [Validators.required]],

    });


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


  saveSemester() {

  }
}
