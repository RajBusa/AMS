import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Karyakar } from 'src/app/models/karyakar.model';

@Component({
  selector: 'app-nirdeshak',
  templateUrl: './nirdeshak.component.html',
  styleUrls: ['./nirdeshak.component.css']
})
export class NirdeshakComponent implements OnInit {
  nirdeshak: Karyakar = {
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
    if(history.state.nirdeshak != undefined){
      console.log(history.state);
      this.nirdeshak = history.state.nirdeshak;
      console.log(this.nirdeshak)
      sessionStorage.setItem("nirdeshak", JSON.stringify(this.nirdeshak))
      sessionStorage.setItem("isSignIn", history.state.isSingIn)
    } else {
      if(sessionStorage.getItem('nirdeshak') == null){
        this.route.navigateByUrl('/signInWithGoogle');
      }
      console.log("Undifined")
      console.log(sessionStorage.getItem('nirdeshak'));
      this.nirdeshak = JSON.parse(sessionStorage.getItem('nirdeshak')!)
    } 
  }

}
