import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Karyakar } from 'src/app/models/karyakar.model';
import { MandalService } from 'src/app/Services/Mandal/mandal.service';
import { MandalKaryakarService } from 'src/app/Services/MandalKaryakar/mandal-karyakar.service';

@Component({
  selector: 'app-sanchalak',
  templateUrl: './sanchalak.component.html',
  styleUrls: ['./sanchalak.component.css']
})
export class SanchalakComponent implements OnInit {
  constructor(private route: Router, private mandalKaryakarService: MandalKaryakarService, private mandalService: MandalService) { }
  sanchalak: Karyakar = {
    id: 0,
    address: '',
    dob: '',
    education: '',
    email: '',
    karayakarNo: 0,
    kshetraId: 0,
    mobileNo: '',
    name: '',
    password: '',
    roleId: 1,
    isActivated: true
  };
  mandalId: number = 0;
  mandalName?: string;
  ngOnInit(): void {
    if(history.state.sanchalak != undefined){
      console.log(history.state);
      this.sanchalak = history.state.sanchalak;
      console.log(this.sanchalak)
      sessionStorage.setItem("sanchalak", JSON.stringify(this.sanchalak))
      sessionStorage.setItem("isSignIn", history.state.isSingIn)
    } else {
      if(sessionStorage.getItem('sanchalak') == null){
        this.route.navigateByUrl('/signInWithGoogle');
      }
      console.log("Undifined")
      console.log(sessionStorage.getItem('sanchalak'));
      this.sanchalak = JSON.parse(sessionStorage.getItem('sanchalak')!)
    } 
    this.getmandalId();
  }

  getmandalId(){
    this.mandalKaryakarService.getMandalId(this.sanchalak.id)
      .subscribe(
        response => {
          this.mandalId = response[0];
          this.mandalService.getMandalName(this.mandalId).subscribe(
            response => {
              this.mandalName = response;
            }
            
          )
        }
      )
  }

  viewYuvakList(){
    this.route.navigateByUrl('/yuvakList', { state: { mandalId: this.mandalId} })
  }
}