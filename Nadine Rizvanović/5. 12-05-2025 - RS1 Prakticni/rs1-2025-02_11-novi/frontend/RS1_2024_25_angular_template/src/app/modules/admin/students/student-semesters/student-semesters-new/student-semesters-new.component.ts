import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {
  StudentGetByIdEndpointService,
  StudentGetByIdResponse
} from '../../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../../shared/snackbars/my-snackbar-helper.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-student-semesters-new',
  standalone: false,

  templateUrl: './student-semesters-new.component.html',
  styleUrl: './student-semesters-new.component.css'
})
export class StudentSemestersNewComponent implements OnInit {


  // Nase globalne varijable
  studentId:number=0;
  student: StudentGetByIdResponse | null = null;

  semesterForm: FormGroup;


  constructor(
    private route: ActivatedRoute,
    private studentGetByIdService:StudentGetByIdEndpointService,
    private snackbar: MySnackbarHelperService,
    private fb: FormBuilder,
  ) {
    this.studentId = this.route.snapshot.params['id'];


    this.semesterForm = this.fb.group({
      academicYearId: [1, [Validators.required]],
      studentId: [this.studentId, [Validators.required]],
      recordedById: [1, [Validators.required]],
      dateOfEntrollment: [new Date(), [Validators.required]],
      yearOfStudy: [null, [Validators.required]],
      price: [null, [Validators.required , Validators.min(50), Validators.max(2000)]],
      renewal: [null, [Validators.required]],
    });

  }

  ngOnInit(): void {
    this.fetchStudent();

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

  }
}
