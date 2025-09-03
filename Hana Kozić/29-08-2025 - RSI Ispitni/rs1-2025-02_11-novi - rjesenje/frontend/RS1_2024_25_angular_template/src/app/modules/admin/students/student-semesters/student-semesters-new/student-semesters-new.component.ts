import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {MySnackbarHelperService} from '../../../../shared/snackbars/my-snackbar-helper.service';
import {
  StudentGetByIdEndpointService, StudentGetByIdResponse
} from '../../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {
  SemesterGetAllByStudentIdEndpoint
} from '../../../../../endpoints/semester-endpoints/semester-get-all-by-student-id-endpoint.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {
  AcademicYearAllEndpoint
} from '../../../../../endpoints/academic-year-endpoints/academic-year-get-all-endpoint.service';
import {
  StudentUpdateOrInsertRequest
} from '../../../../../endpoints/student-endpoints/student-update-or-insert-endpoint.service';
import {
  SemesterUpdateOrInsertEndpoint,
  SemesterUpdateOrInsertRequest
} from '../../../../../endpoints/semester-endpoints/semester-update-or-insert-endpoint.service';
import {MyAuthService} from '../../../../../services/auth-services/my-auth.service';

@Component({
  selector: 'app-student-semesters-new',
  standalone: false,

  templateUrl: './student-semesters-new.component.html',
  styleUrl: './student-semesters-new.component.css'
})
export class StudentSemestersNewComponent implements OnInit {


  // Nase varijable
  studentId:number = 0;
  //student:any;
  student: StudentGetByIdResponse | null = null;
  semesters:any;
  academicYears: any;

  semesterForm: FormGroup;


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private snackbar: MySnackbarHelperService,
    private studentGetByIdService:StudentGetByIdEndpointService,
    private semesterGetAllByStudentIdService:SemesterGetAllByStudentIdEndpoint,
    private fb: FormBuilder,
    private academicYearAllService:AcademicYearAllEndpoint,
    private semesterUpdateOrInsertService:SemesterUpdateOrInsertEndpoint,
    private myAuthService:MyAuthService
  ) {

    this.studentId = route.snapshot.params['id'];

    this.semesterForm = this.fb.group({

      academicYearId: [1, [Validators.required]],
      studentId: [this.studentId, [Validators.required]],
      recordedById: [ myAuthService.getMyAuthInfo()?.userId, [Validators.required]],
      dateOfEnrollment: [new Date(), [Validators.required]],
      yearOfStudy: [ null, [Validators.required]],
      price: [{value:null , disabled: true} , [Validators.required, Validators.min(50), Validators.max(2000)]],
      renewal: [{value:false , disabled: true}, [Validators.required]],

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

        console.error('Error saving semester', error);
      },
    });

  }

  private fetchAcademicYears() {

    this.academicYearAllService.handleAsync().subscribe({
      next: (data) => {

        this.academicYears = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching academic years. Please try again.', 5000);
        console.error('Error fetching academic years:', err);
      }
    });


  }

  yearChanged($event: any) {

    const studyYear = parseInt($event.target.value);

    if(this.semesters.some((x:any) => x.yearOfStudy == studyYear)) {

      this.semesterForm.patchValue({
        price: 400,
        renewal: true
      })

    }else{

      this.semesterForm.patchValue({
        price: 1800,
        renewal: false
      })

    }


  }
}
