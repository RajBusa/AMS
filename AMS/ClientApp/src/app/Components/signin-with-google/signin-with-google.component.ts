import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SignIn } from 'src/app/models/signIn.model';
import { KaryakarService } from 'src/app/Services/Karyakar/karyakar.service';

@Component({
  selector: 'app-signin-with-google',
  templateUrl: './signin-with-google.component.html',
  styleUrls: ['./signin-with-google.component.css']
})
export class SigninWithGoogleComponent implements OnInit {
  signIn: SignIn = {
    email: '',
    password: ''
  };

  constructor(private karyakarService: KaryakarService, private route: Router) { }

  ngOnInit(): void {

  }
  SignIn() {
    this.karyakarService.login(this.signIn)
      .subscribe(
        response => {
          console.log(response)
          if (response == -1) {
            this.route.navigate(['/', 'newPassword'])
          } else if (response == 0) {

          } else if (response == (-2)) {
            let alert = document.getElementById('alert');
            // console.log(abc)
            alert!.innerHTML = `<div class="alert alert-danger alert-dismissible fade show" role="alert">Enter correct Password
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>`
            setTimeout(() => {
              alert!.innerHTML = '';
            }, 2000);
          } else  {
            this.karyakarService.getKaryakar(response)
            .subscribe(
              response=>{
                console.log(response[0])
                console.log(typeof response)
                if(response[0].roleId == 1){
                  this.route.navigate(['/sampark'], {queryParams: {samparkKaryakar :JSON.stringify(response[0])}})
                } else if(response[0].roleId == 2) {
                  this.route.navigate(['/sanchalak'], {queryParams: {sanchalak :JSON.stringify(response[0])}})
                } else if(response[0].roleId == 3) { 
                  this.route.navigate(['/nirikshak'], {queryParams: {nirikshak :JSON.stringify(response[0])}})
                } else if(response[0].roleId == 4) {
                  this.route.navigate(['/nirdeshak'], {queryParams: {nirdeshak :JSON.stringify(response[0])}})
                }
              }
            )
          }
        }
      )
  }
}
