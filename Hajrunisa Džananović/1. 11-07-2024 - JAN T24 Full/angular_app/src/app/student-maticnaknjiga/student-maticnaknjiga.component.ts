import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";

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
  student:any;
  upisi:any;
  akademske:any;
  ovjeri_upis:any;


  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {

    this.route.params.subscribe(params => {
      this.studentID = params['id'];
    })

  }





  ngOnInit(): void {
    this.GetStudent();
    this.GetUpisiStudenta();
    this.GetAkademske();
  }

  private GetStudent() {

    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetStudent", {

      headers: {
        'autentifikacija-token' : AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.vrijednost
      },


      params:{studentid:this.studentID},
      observe:'response'

    } ).subscribe(response=>{

      this.student = response.body;

    });


  }


  private GetUpisiStudenta() {

    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetUpisiStudenta", {

      headers: {
        'autentifikacija-token' : AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.vrijednost
      },


      params:{studentid:this.studentID},
      observe:'response'

    } ).subscribe(response=>{

      this.upisi = response.body;

    });


  }

  NoviUpis() {

    this.novi_upis = {

      studentid : this.studentID,
      evidentiraoid : AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId,
      datumUpis : new Date()
      // datumUpis : new Date().toISOString().split("T")[0],

    }


  }

  private GetAkademske() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetAkademskeGodine", MojConfig.http_opcije()).subscribe(x=>{
      this.akademske = x;
    });
  }

  SpasiUpis() {

    this.httpKlijent.post(MojConfig.adresa_servera + "/DodajUpis", this.novi_upis, MojConfig.http_opcije())
      .subscribe((x: any) => {

        this.ngOnInit();  // refresh
        this.novi_upis = null; // zatvaranje modala

        porukaSuccess("Upis je dodan");
      } ,error => {
        porukaError("Upis nije dodan zato sto je ta godina vec upisana a niste odabrali obnovu");
      } );


  }

  OvjeriUpis() {

    this.httpKlijent.post(MojConfig.adresa_servera + "/OvjeriUpis", this.ovjeri_upis, MojConfig.http_opcije())
      .subscribe((x: any) => {

        this.ngOnInit();  // refresh
        this.ovjeri_upis = null; // zatvaranje modala

        porukaSuccess("Upis je ovjeren");
      } ,error => {
        porukaError("Upis nije ovjeren");
      } );

  }
}
