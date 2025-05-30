import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  StudentGetByIdEndpointService, StudentGetByIdResponse
} from '../../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../../shared/snackbars/my-snackbar-helper.service';
import {
  SemesterGetByStudentIdEndpoint
} from '../../../../../endpoints/semester-endpoints/semester-get-by-student-id-endpoint.service';
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
export class StudentSemestersNewComponent implements OnInit{


  // Nase varijable

  studentId: any;
  //student:any;
  student: StudentGetByIdResponse | null = null;
  semesterForm: FormGroup;
  academicYears:any;


  constructor( private route: ActivatedRoute,
               private router: Router,
               private studentGetByIdService:StudentGetByIdEndpointService,
               private snackbar: MySnackbarHelperService,
               private semesterGetByStudentIdService:SemesterGetByStudentIdEndpoint,
               private fb: FormBuilder,
               private academicYearGetAllService:AcademicYearGetAllEndpoint,
               private semesterUpdateOrInsertService:SemesterUpdateOrInsertEndpoint
  ) {

    this.studentId = this.route.snapshot.params['id'];


    this.semesterForm = this.fb.group({

      academicYearId: [1, [Validators.required]],
      studentId: [this.studentId, [Validators.required]],
      recordedById: [1, [Validators.required]],
      dateOfEnrollment: [new Date(), [Validators.required]],
      studyYear: [null, [Validators.required]],
      price: [null, [Validators.required, Validators.min(50), Validators.max(2000)  ]],
      renewal: [false, [Validators.required]],

    });


  }

  ngOnInit(): void {

    this.fetchStudent();
    this.fetchAcademicYears();

    }

  private fetchStudent() {

    this.studentGetByIdService.handleAsync(this.studentId).subscribe({
      next: ( data ) => {

        this.student = data;


      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching student. Please try again.', 5000);
        console.error('Error fetching student:', err);
      }
    });


  }


  saveSemester() {

    if (this.semesterForm.invalid) return;

    const semesterData: SemesterUpdateOrInsertRequest = {
      ...this.semesterForm.value,
    };

    this.semesterUpdateOrInsertService.handleAsync(semesterData).subscribe({
      next: () => {


        this.router.navigate(['/admin/students/semesters',this.studentId]);
      },
      error: (error) => {
        this.snackbar.showMessage('Error adding semester. Please try again.', 5000);
        console.error('Error saving semester', error);
      },
    });



  }

  private fetchAcademicYears() {

    this.academicYearGetAllService.handleAsync().subscribe({
      next: ( data ) => {

        this.academicYears = data;


      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching academic years. Please try again.', 5000);
        console.error('Error fetching academic years:', err);
      }
    });


  }
}
