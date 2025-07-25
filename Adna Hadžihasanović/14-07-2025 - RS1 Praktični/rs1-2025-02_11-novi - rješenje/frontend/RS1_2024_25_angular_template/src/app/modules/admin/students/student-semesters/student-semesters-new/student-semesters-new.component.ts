import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  StudentGetByIdEndpointService, StudentGetByIdResponse
} from '../../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../../shared/snackbars/my-snackbar-helper.service';
import {MatDialog} from '@angular/material/dialog';
import {
  SemesterGetAllByStudentIdEndpoint
} from '../../../../../endpoints/semester-endpoints/semester-get-all-by-student-id-endpoint.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
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
export class StudentSemestersNewComponent implements OnInit  {

  // Nase varijable
  studentId: number = 0;
  //student:any;
  student: StudentGetByIdResponse | null = null;
  semesters:any;
  semesterForm: FormGroup;
  academicYears:any;

  loggedInUserId:number = 0;

  constructor(    private route: ActivatedRoute,
                  private router: Router,
                  private studentGetByIdService:StudentGetByIdEndpointService,
                  private snackbar: MySnackbarHelperService,
                  private dialog: MatDialog,
                  private semesterGetAllByStudentIdService:SemesterGetAllByStudentIdEndpoint,
                  private fb: FormBuilder,
                  private academicYearGetAllService:AcademicYearGetAllEndpoint,
                  private semesterUpdateOrInsertService:SemesterUpdateOrInsertEndpoint
  ) {

    this.studentId = this.route.snapshot.params['id'];

    const authData = localStorage.getItem('my-auth-token');

    if(authData){

      const JSONAuth = JSON.parse(authData);

      this.loggedInUserId = JSONAuth.myAuthInfo.userId;

    }



    this.semesterForm = this.fb.group({

      academicYearId: [1, [Validators.required]],
      studentId: [this.studentId, [Validators.required]],
      recordedById: [this.loggedInUserId, [Validators.required]],
      dateOfEnrollment: [new Date(), [Validators.required]],
      yearOfStudy: [null, [Validators.required]],
      price: [ {value: null , disabled: true} , [Validators.required, Validators.max(2000), Validators.min(50) ]],
      renewal: [{value: false , disabled: true}, [Validators.required]],

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

        this.snackbar.showMessage('Academic Year already exists.', 5000);

        console.error('Academic Year already exists.');
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

  yearOfStudyChanged($event: any) {

    const studyYear = parseInt($event.target.value);

    if(this.semesters.some((x:any)=> x.yearOfStudy == studyYear )){


      this.semesterForm.patchValue(
        {
          price:400,
          renewal:true,
        }
      )

    }else{

      this.semesterForm.patchValue(
        {
          price:1800,
          renewal:false,
        }
      )

    }


  }
}
