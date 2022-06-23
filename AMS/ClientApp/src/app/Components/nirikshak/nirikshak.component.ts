import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Karyakar } from 'src/app/models/karyakar.model';

@Component({
  selector: 'app-nirikshak',
  templateUrl: './nirikshak.component.html',
  styleUrls: ['./nirikshak.component.css']
})
export class NirikshakComponent implements OnInit {
  nirikshak: Karyakar = {
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
  constructor(private route: Router) { }
  
  ngOnInit(): void {
    if(history.state.nirikshak != undefined){
      console.log(history.state);
      this.nirikshak = history.state.nirikshak;
      console.log(this.nirikshak)
      sessionStorage.setItem("nirikshak", JSON.stringify(this.nirikshak))
      sessionStorage.setItem("isSignIn", history.state.isSingIn)
    } else {
      if(sessionStorage.getItem('nirikshak') == null){
        this.route.navigateByUrl('/signInWithGoogle');
      }
      console.log("Undifined")
      console.log(sessionStorage.getItem('nirikshak'));
      this.nirikshak = JSON.parse(sessionStorage.getItem('nirikshak')!)
    }
  }

}
