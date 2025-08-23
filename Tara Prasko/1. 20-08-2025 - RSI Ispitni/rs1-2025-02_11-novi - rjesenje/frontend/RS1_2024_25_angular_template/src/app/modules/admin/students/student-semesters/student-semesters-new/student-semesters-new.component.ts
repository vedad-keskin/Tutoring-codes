import {Component, OnInit} from '@angular/core';
import {
  StudentGetByIdEndpointService,
  StudentGetByIdResponse
} from '../../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {ActivatedRoute, Router} from '@angular/router';
import {MySnackbarHelperService} from '../../../../shared/snackbars/my-snackbar-helper.service';
import {
  SemesterGetAllByStudentIdEndpoint
} from '../../../../../endpoints/semester-endpoints/semester-get-by-id-endpoint.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MyAuthService} from '../../../../../services/auth-services/my-auth.service';
import {
  AcademicYearGetAllEndpoint
} from '../../../../../endpoints/academic-year-endpoints/academic-year-get-all-endpoint.service';
import {
  StudentUpdateOrInsertRequest
} from '../../../../../endpoints/student-endpoints/student-update-or-insert-endpoint.service';
import {
  SemesterUpdateOrInsertEndpoint,
  SemesterUpdateOrInsertRequest
} from '../../../../../endpoints/semester-endpoints/semester-update-or-insert-endpoint.service';

@Component({
  selector: 'app-student-semesters-new',
  standalone: false,

  templateUrl: './student-semesters-new.component.html',
  styleUrl: './student-semesters-new.component.css'
})
export class StudentSemestersNewComponent implements OnInit {

  studentId: number = 0;
  //student:any;
  student : StudentGetByIdResponse | null = null;
  semesters:any;

  semesterForm: FormGroup;
  academicYears:any;


  constructor(    private route: ActivatedRoute,
                  private router: Router,
                  private snackbar: MySnackbarHelperService,
                  private studentGetByIdService:StudentGetByIdEndpointService,
                  private semesterGetAllByStudentIdService:SemesterGetAllByStudentIdEndpoint,
                  private fb: FormBuilder,
                  private myAuthService:MyAuthService,
                  private academicYearGetAllService:AcademicYearGetAllEndpoint,
                  private semesterUpdateOrInsertService:SemesterUpdateOrInsertEndpoint
  )
  {

    this.studentId = route.snapshot.params['id'];

    this.semesterForm = this.fb.group({

      academicYearId: [1, [Validators.required]],
      studentId: [ this.studentId , [Validators.required]],
      recordedById: [ myAuthService.getMyAuthInfo()?.userId , [Validators.required]],
      dateOfEnrollment: [new Date(), [Validators.required]],
      yearOfStudy: [null, [Validators.required]],
      price: [{value: null, disabled: true}, [Validators.required, Validators.min(50), Validators.max(2000) ]],
      renewal: [{value: false, disabled: true}, [Validators.required]],

    });

  }

  ngOnInit(): void {

    this.fetchStudent();
    this.fetchSemesters();
    this.fetchAcademicYears();
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

  private fetchSemesters() {
    this.semesterGetAllByStudentIdService.handleAsync(this.studentId).subscribe({
      next: (data) => {


        this.semesters = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching semesters. Please try again.', 5000);
        console.error('Error fetching semesters:', err);
      }
    });

  }

  saveSemester() {

    if (this.semesterForm.invalid) return;

    const semesterData: SemesterUpdateOrInsertRequest = {

      ...this.semesterForm.getRawValue(),
    };

    this.semesterUpdateOrInsertService.handleAsync(semesterData).subscribe({
      next: () => {

        this.router.navigate(['/admin/students/semesters', this.studentId]);
      },
      error: (error) => {
        this.snackbar.showMessage('Academic year already exists. Please try again.', 5000);
        console.error('Error saving semester', error);
      },
    });


  }

  private fetchAcademicYears() {

    this.academicYearGetAllService.handleAsync().subscribe({
      next: (data) => {


        this.academicYears = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching academic years. Please try again.', 5000);
        console.error('Error fetching academic years:', err);
      }
    });

  }

  YearChanged($event: any) {

    const StudyYear: number = parseInt($event.target.value);


    if(this.semesters.some((x:any) => x.yearOfStudy == StudyYear )){

      this.semesterForm.patchValue({

        price: 400,
        renewal: true

      });

    }else{

      this.semesterForm.patchValue({

        price: 1800,
        renewal: false

      });


    }



  }
}
