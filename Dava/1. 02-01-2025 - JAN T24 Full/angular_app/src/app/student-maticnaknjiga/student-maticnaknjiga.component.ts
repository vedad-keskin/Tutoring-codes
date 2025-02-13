import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {

    this.route.params.subscribe(params => {
      this.studentID=params['id'];
    })
  }

   novi_upis:any;
   studentID:any;
   student:any;
   upisi:any;
   akademske:any;
   ovjeri_upis:any;

  ngOnInit(): void {
    this.GetStudent();
    this.GetUpisiStudenta();
    this.GetAkademske();
  }

  private GetStudent() {

    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetById", {

      headers:{
        'autentifikacija-token' : AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.vrijednost
      },


      params:{studentid:this.studentID},
      observe: "response",

    } ).subscribe(response=>{
      this.student = response.body;
    });

  }


  private GetUpisiStudenta() {

    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetUpisiStudenta", {

      headers:{
        'autentifikacija-token' : AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.vrijednost
      },


      params:{studentid:this.studentID},
      observe: "response",

    } ).subscribe(response=>{
      this.upisi = response.body;
    });


  }

  NoviUpis() {

    this.novi_upis = {

      studentid: this.studentID,
      evidentiraoid: AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId,
      datumUpis: new Date()

    }

  }

  private GetAkademske() {

    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetAkademske", MojConfig.http_opcije()).subscribe(x=>{
      this.akademske = x;
    });

  }


  SpasiUpis() {

    this.httpKlijent.post(MojConfig.adresa_servera + "/UpisiGodinu", this.novi_upis, MojConfig.http_opcije())
      .subscribe((x: any) => {

        this.ngOnInit();
        this.novi_upis = null;

        porukaSuccess("Upis je evidentiran");
      },error => {
        porukaError("Niste odabrani obnovu a vec ste ranije upisali tu godina");
      });

  }

  OvjeriUpis() {


    this.httpKlijent.post(MojConfig.adresa_servera + "/OvjeriGodinu", this.ovjeri_upis, MojConfig.http_opcije())
      .subscribe((x: any) => {

        this.ngOnInit();
        this.ovjeri_upis = null;

        porukaSuccess("Upis je ovjeren");
      },error => {
        porukaError("Upis nije ovjeren");
      });

  }
}
