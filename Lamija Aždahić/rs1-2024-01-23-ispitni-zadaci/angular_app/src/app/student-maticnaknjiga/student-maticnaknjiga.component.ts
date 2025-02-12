import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {


  novi_upis:any;
  studentID:any;


  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {


    this.route.params.subscribe(params => {
      this.studentID = params['id'];
    })

  }


  ngOnInit(): void {
  }
}
