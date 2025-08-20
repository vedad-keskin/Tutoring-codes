import {Component, Inject, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  StudentGetByIdEndpointService, StudentGetByIdResponse
} from '../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {
  StudentUpdateOrInsertEndpointService
} from '../../../../endpoints/student-endpoints/student-update-or-insert-endpoint.service';
import {
  MunicipalityLookupEndpointService
} from '../../../../endpoints/lookup-endpoints/municipality-lookup-endpoint.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {MySnackbarHelperService} from '../../../shared/snackbars/my-snackbar-helper.service';

@Component({
  selector: 'app-student-semesters',
  standalone: false,

  templateUrl: './student-semesters.component.html',
  styleUrl: './student-semesters.component.css'
})
export class StudentSemestersComponent implements OnInit {

  studentId: number = 0;
  //student:any;
  student : StudentGetByIdResponse | null = null;



  constructor(    private route: ActivatedRoute,
                  private router: Router,
                  private snackbar: MySnackbarHelperService,
                  private studentGetByIdService:StudentGetByIdEndpointService
  )
  {

    this.studentId = route.snapshot.params['id'];

  }

  ngOnInit(): void {

    this.fetchStudent();

    }


  private fetchStudent() {

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
}
