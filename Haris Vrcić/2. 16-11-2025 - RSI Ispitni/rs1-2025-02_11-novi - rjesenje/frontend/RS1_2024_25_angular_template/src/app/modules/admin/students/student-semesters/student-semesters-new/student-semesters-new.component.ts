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


  // Nase varijable

  studentId: number = 0;
  //student:any;

  student: StudentGetByIdResponse | null = null;

  semesters:any;
  academicYears:any;


  semesterForm: FormGroup;




  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private studentGetByIdService:StudentGetByIdEndpointService,
    private snackbar: MySnackbarHelperService,
    private semesterGetAllByStudentIdService:SemesterGetAllByStudentIdEndpoint,
    private fb: FormBuilder,
    private myAuthService:MyAuthService,
    private academicYearGetAllService:AcademicYearGetAllEndpoint,
    private semesterUpdateOrInsertService:SemesterUpdateOrInsertEndpoint
  ) {

    this.studentId = this.route.snapshot.params['id'];


    this.semesterForm = this.fb.group({

      academicYearId: [1, [Validators.required]],
      studentId: [this.studentId, [Validators.required]],
      recordedById: [myAuthService.getMyAuthInfo()?.userId, [Validators.required]],
      dateOfEnrollment: [new Date(), [Validators.required]],
      yearOfStudy: [null, [Validators.required]],
      price: [null, [Validators.required, Validators.min(50), Validators.max(2000)]],
      renewal: [false, [Validators.required]],

    });

  }

  ngOnInit(): void {

    this.GetStudent();
    this.GetSemesters();
    this.GetAcademicYears();

  }


  private GetStudent() {


    this.studentGetByIdService.handleAsync(this.studentId).subscribe({
      next: (data) => {
        this.snackbar.showMessage('Student successfully fetched.');

        this.student = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching student. Please try again.', 5000);
        console.error('Error fetching student:', err);
      }
    });

  }

  private GetSemesters() {

    this.semesterGetAllByStudentIdService.handleAsync(this.studentId).subscribe({
      next: (data) => {
        this.snackbar.showMessage('Semesters successfully fetched.');

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
      ...this.semesterForm.value,
    };

    this.semesterUpdateOrInsertService.handleAsync(semesterData).subscribe({
      next: () => {
        this.snackbar.showMessage('Semester successfully saved.');

        this.router.navigate(['/admin/students/semesters', this.studentId]);
      },
      error: (error) => {
        this.snackbar.showMessage('Error saving semester. Please try again.');
        console.error('Error saving semester', error);
      },
    });


  }

  private GetAcademicYears() {

    this.academicYearGetAllService.handleAsync().subscribe({
      next: (data) => {
        this.snackbar.showMessage('Academic years successfully fetched.');

        this.academicYears = data;

      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching academic years. Please try again.', 5000);
        console.error('Error fetching academic years:', err);
      }
    });


  }
}
