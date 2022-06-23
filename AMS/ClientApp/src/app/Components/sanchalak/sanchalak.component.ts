import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Karyakar } from 'src/app/models/karyakar.model';

@Component({
  selector: 'app-sanchalak',
  templateUrl: './sanchalak.component.html',
  styleUrls: ['./sanchalak.component.css']
})
export class SanchalakComponent implements OnInit {
  constructor(private route: Router) { }
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
  }
}