import {Component, Inject} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  StudentGetByIdEndpointService
} from '../../../../endpoints/student-endpoints/student-get-by-id-endpoint.service';
import {
  StudentUpdateOrInsertEndpointService
} from '../../../../endpoints/student-endpoints/student-update-or-insert-endpoint.service';
import {
  MunicipalityLookupEndpointService
} from '../../../../endpoints/lookup-endpoints/municipality-lookup-endpoint.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-student-semesters',
  standalone: false,

  templateUrl: './student-semesters.component.html',
  styleUrl: './student-semesters.component.css'
})
export class StudentSemestersComponent {

  studentId: number = 0;


  constructor(    private route: ActivatedRoute,
                  private router: Router,
                  private snackBar: MatSnackBar
  )
  {

    this.studentId = route.snapshot.params['id'];


  }


}
