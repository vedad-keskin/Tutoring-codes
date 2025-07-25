import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  StudentGetByIdEndpointService,
  StudentGetByIdResponse
} from '../../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../../shared/snackbars/my-snackbar-helper.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {
  AcademicYearGetAllEndpoint
} from '../../../../../endpoints/academic-year-endpoints/academic-year-get-all-endpoint.service';
import {
  StudentUpdateOrInsertRequest
} from '../../../../../endpoints/student-endpoints/student-update-or-insert-endpoint.service';
import {
  SemesterInsertOrUpdateEndpoint,
  SemesterUpdateOrInsertRequest
} from '../../../../../endpoints/semester-endpoints/semester-update-or-insert-endpoint.service';

@Component({
  selector: 'app-student-semesters-new',
  standalone: false,

  templateUrl: './student-semesters-new.component.html',
  styleUrl: './student-semesters-new.component.css'
})
export class StudentSemestersNewComponent implements OnInit {


  // Nase globalne varijable
  studentId: number = 0;

  student: StudentGetByIdResponse | null = null;
  academicYears:any;

  semesterForm: FormGroup;


  constructor(
    private route: ActivatedRoute,
    private studentGetByIdService:StudentGetByIdEndpointService,
    private snackbar: MySnackbarHelperService,
    private fb: FormBuilder,
    private academicYearGetAllService:AcademicYearGetAllEndpoint,
    private semesterInsertOrUpdateService:SemesterInsertOrUpdateEndpoint,
    private router: Router,
  ) {
    this.studentId = this.route.snapshot.params['id'];


    //   academicYearId:number;
    //   studentId:number;
    //   recordedById:number;
    //   dateOfEntrollment:Date;
    //   yearOfStudy:number;
    //   price:number;
    //   renewal:boolean;

    this.semesterForm = this.fb.group({
      academicYearId: [1, [Validators.required]],
      studentId: [this.studentId, [Validators.required]],
      recordedById: [1, [Validators.required]],
      dateOfEntrollment: [new Date(), [Validators.required]],
      yearOfStudy: [null, [Validators.required]],
      price: [null, [Validators.required , Validators.min(50), Validators.max(2000)]],
      renewal: [false, [Validators.required]],
    });

  }

  ngOnInit(): void {
    this.fetchStudent();
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

  saveSemester() {

    if (this.semesterForm.invalid) return;

    const semesterData: SemesterUpdateOrInsertRequest = {
      ...this.semesterForm.value,
    };

    this.semesterInsertOrUpdateService.handleAsync(semesterData).subscribe({
      next: () => {

        this.router.navigate(['/admin/students/semesters', this.studentId]);
      },
      error: (error) => {
        this.snackbar.showMessage('Academic Year already exists.', 5000);
        console.error('Error adding semester', error);
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
}
