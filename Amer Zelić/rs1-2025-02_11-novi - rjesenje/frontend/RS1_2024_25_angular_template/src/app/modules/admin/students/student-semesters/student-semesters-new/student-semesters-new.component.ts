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
import {
  AcademicYearGetAllEndpoint
} from '../../../../../endpoints/academic-year-endpoints/academic-year-get-all-endpoint.service';
import {
  StudentUpdateOrInsertRequest
} from '../../../../../endpoints/student-endpoints/student-update-or-insert-endpoint.service';
import {
  SemesterUpdateOrInsertEndpoint,
  SemesterUpdateOrInsertRequest
} from '../../../../../endpoints/semester-endpoint/semester-update-or-insert-endpoint.service';

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
  academicYears:any;




  constructor(    private route: ActivatedRoute,
                  private router: Router,
                  private studentGetByIdService:StudentGetByIdEndpointService,
                  private snackbar: MySnackbarHelperService,
                  private semesterGetByStudentIdService:SemesterGetByStudentIdEndpoint,
                  private fb: FormBuilder,
                  private myAuthService:MyAuthService,
                  private academicYearGetAllService:AcademicYearGetAllEndpoint,
                  private semesterUpdateOrInsertService:SemesterUpdateOrInsertEndpoint

  ) {

    this.studentId = route.snapshot.params['id'];

    this.semesterForm = this.fb.group({

      winterSemester: [new Date(), [Validators.required]],
      yearOfStudy: [null, [Validators.required]],
      price: [{value: null , disabled:true}, [Validators.required, Validators.min(50), Validators.max(2000)]],
      renewal: [{value: false , disabled:true}, [Validators.required]],
      academicYearId: [1, [Validators.required]],
      studentId: [this.studentId, [Validators.required]],
      recordedById: [myAuthService.getMyAuthInfo()?.userId, [Validators.required]],

    });


  }

  ngOnInit(): void {

    this.getByIdStudent();
    this.fetchSemesters();
    this.fetchAcademicYear();

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

    if (this.semesterForm.invalid) return;

    const semesterData: SemesterUpdateOrInsertRequest = {
      ...this.semesterForm.getRawValue(),
    };

    this.semesterUpdateOrInsertService.handleAsync(semesterData).subscribe({
      next: () => {
        this.router.navigate(['/admin/students/semesters',this.studentId]);
      },
      error: (error) => {
        this.snackbar.showMessage('Academic year already exists', 5000);
      },
    });


  }

  private fetchAcademicYear() {

    this.academicYearGetAllService.handleAsync().subscribe({
      next: (data) => {

        this.academicYears = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error getting academic years. Please try again.', 5000);
        console.error('Error getting academic years:', err);
      }
    });

  }

  yearChanged($event: any) {

    const year:number = parseInt($event.target.value, 10);


    if(this.semesters.some((x:any) => x.yearOfStudy == year)){

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
