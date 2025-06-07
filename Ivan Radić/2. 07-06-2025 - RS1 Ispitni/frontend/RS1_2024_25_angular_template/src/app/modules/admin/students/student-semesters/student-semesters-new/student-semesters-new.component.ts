import {Component, OnInit} from '@angular/core';
import {
  StudentGetByIdEndpointService,
  StudentGetByIdResponse
} from '../../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {ActivatedRoute, Router} from '@angular/router';
import {MySnackbarHelperService} from '../../../../shared/snackbars/my-snackbar-helper.service';
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

  studentId:number= 0;
  // student:any;
  student: StudentGetByIdResponse | null = null;
  semesterForm: FormGroup;
  academicYears:any;
  loggedInUserId:number = 0;
  semesters:any;




  constructor(    private route: ActivatedRoute,
                  private router: Router,
                  private studentGetByIdService:StudentGetByIdEndpointService,
                  private snackbar: MySnackbarHelperService,
                  private semesterGetAllByStudentIdService:SemesterGetAllByStudentIdEndpoint,
                  private fb: FormBuilder,
                  private semesterUpdateOrInsertService:SemesterUpdateOrInsertEndpoint ,
                  private academicYearGetAllService:AcademicYearGetAllEndpoint
  ) {

    this.studentId = this.route.snapshot.params['id'];


    const authData = localStorage.getItem('my-auth-token');

    if(authData){

      const JSONAuth = JSON.parse(authData);

      this.loggedInUserId = JSONAuth.myAuthInfo.userId;


    }



    this.semesterForm = this.fb.group({

      studyYear: [null, [Validators.required]],
      renewal: [{value:false ,  disabled:true }, [Validators.required]],
      dateOfEnrollment: [new Date(), [Validators.required]],
      price: [ {value:null ,  disabled:true }, [Validators.required , Validators.min(50), Validators.max(2000)  ]],
      academicYearId: [1, [Validators.required]],
      studentId: [ this.studentId , [Validators.required]],
      recordedById: [ this.loggedInUserId , [Validators.required]],

    });


  }

  ngOnInit(): void {

    this.fetchStudent();
    this.fetchAcademicYears();
    this.fetchSemesters();

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

  private fetchStudent() {

    this.studentGetByIdService.handleAsync(this.studentId).subscribe({
      next: (data) => {

        this.student = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error restoring student. Please try again.', 5000);
        console.error('Error restoring student:', err);
      }
    });


  }


  saveSemester() {


    if (this.semesterForm.invalid) return;

    const semesterData: SemesterUpdateOrInsertRequest = {
      ...this.semesterForm.value,
      price: this.semesterForm.get('price')?.value,
      renewal : this.semesterForm.get('renewal')?.value,

    };

    this.semesterUpdateOrInsertService.handleAsync(semesterData).subscribe({
      next: () => {
        this.router.navigate(['/admin/students/semesters',this.studentId]);
      },
      error: (error) => {
        console.error('Error saving student', error);
      },
    });


  }

  private fetchAcademicYears() {

    this.academicYearGetAllService.handleAsync().subscribe({
      next: (data) => {

        this.academicYears = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error restoring student. Please try again.', 5000);
        console.error('Error restoring student:', err);
      }
    });


  }

  YearChanged($event: any) {

    const StudyYear: number = parseInt($event.target.value, 10);

    if(this.semesters.some((x:any) => x.studyYear == StudyYear) ){

      this.semesterForm.patchValue({

        price:400,
        renewal:true,

      })

    }else{

      this.semesterForm.patchValue({

        price:1800,
        renewal:false,

      })

    }


  }
}
