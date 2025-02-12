import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})

export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;


  opstine:any;
  novi_student:any;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  testirajWebApi() :void
  {
  // http://localhost:5000/Student/GetAll
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });

  }

  ngOnInit(): void {
    this.testirajWebApi();
    this.fetchOpstine();
  }

  FiltirajStudente() {

    return this.studentPodaci.filter( (x:any) =>

      ((x.ime + " "+ x.prezime).toLowerCase().startsWith(this.ime_prezime.toLowerCase())
        || (x.prezime + " "+ x.ime).toLowerCase().startsWith(this.ime_prezime.toLowerCase()) )

      &&

      (x.opstina_rodjenja.description.toLowerCase().startsWith(this.opstina.toLowerCase()) )

    );


  }

  private fetchOpstine() {

    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetOpstine", MojConfig.http_opcije()).subscribe(x=>{
      this.opstine = x;
    });

  }

  NoviStudent() {

    this.novi_student = {
      ime: "",
      prezime : "",
      opstina_rodjenja_id: 1

    }


  }

  SpasiStudenta() {


    this.httpKlijent.post(MojConfig.adresa_servera + "/DodajStudent", this.novi_student, MojConfig.http_opcije())
      .subscribe((x: any) => {


        this.ngOnInit();
        this.novi_student = null;

        porukaSuccess("Student je dodan");
      });



  }
}
