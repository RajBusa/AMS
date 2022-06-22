import { Component, OnInit } from '@angular/core';
import { SignIn } from 'src/app/models/signIn.model';
import { KaryakarService } from 'src/app/Services/Karyakar/karyakar.service';

@Component({
  selector: 'app-new-password',
  templateUrl: './new-password.component.html',
  styleUrls: ['./new-password.component.css']
})
export class NewPasswordComponent implements OnInit {
  user: SignIn = {
    email: '',
    password: ''
  }
  confirmPassword: string = '';
  constructor(private karyakarService: KaryakarService) { }

  ngOnInit(): void {
  }

  signUp(){
    if(this.user.password == this.confirmPassword){
      this.karyakarService.signUp(this.user)
        .subscribe(
          response => {
            console.log(response)
          }
        )
    }
  }
}
