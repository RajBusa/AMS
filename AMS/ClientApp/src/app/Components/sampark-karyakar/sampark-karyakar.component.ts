import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Karyakar } from 'src/app/models/karyakar.model';

@Component({
  selector: 'app-sampark-karyakar',
  templateUrl: './sampark-karyakar.component.html',
  styleUrls: ['./sampark-karyakar.component.css']
})
export class SamparkKaryakarComponent implements OnInit {
  samparkKaryakar: Karyakar = {
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

  isSignIn: string = '';
  constructor(private route: Router) { }

  ngOnInit(): void {
    if(history.state.samparkKaryakar != undefined){
      console.log(history.state);
      this.samparkKaryakar = history.state.samparkKaryakar;
      console.log(this.samparkKaryakar)
      sessionStorage.setItem("samparkKaryakar", JSON.stringify(this.samparkKaryakar))
      sessionStorage.setItem("isSignIn", history.state.isSingIn)
    } else {
      if(sessionStorage.getItem('samparkKaryakar') == null){
        this.route.navigateByUrl('/signInWithGoogle');
      }
      console.log("Undifined")
      console.log(sessionStorage.getItem('samparkKaryakar'));
      this.samparkKaryakar = JSON.parse(sessionStorage.getItem('samparkKaryakar')!);
      this.isSignIn = sessionStorage.getItem('isSignIn')!;
      // console.log(sessionStorage.getItem('isSignIn')!)
      // console.log(typeof sessionStorage.getItem('isSignIn')!)
    }
  }
}