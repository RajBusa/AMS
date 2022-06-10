import { Component, OnInit} from '@angular/core';
import { Yuvak } from 'src/app/models/yuvak.model';
import { ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';
import { YuvakService } from 'src/app/Services/Yuvak/yuvak.service';
import { SamparkKaryakar } from 'src/app/models/samparkKaryakar.model';
import { flatten } from '@angular/compiler';


@Component({
  selector: 'app-yuvak-profile',
  templateUrl: './yuvak-profile.component.html',
  styleUrls: ['./yuvak-profile.component.css']
})
export class YuvakProfileComponent implements OnInit {
  samparkKaryakars: SamparkKaryakar[] = [];
  syRole?: string;
  mandalId: number = 0 ;
  yuvak :Yuvak = {
    id: 0,
    name: '',
    dob: '  ',
    address: '',
    mobile: '',
    education: '',
    email: '',
    mandalId: 1,
    samparkId: 1,
    count: 1,
    isSamparkKaryakar: false,
    isAttendanceTaken:false
  };
  constructor(private route: ActivatedRoute, private yuvakServices: YuvakService) { }

  ngOnInit(): void {

    
    this.route.queryParams.subscribe(
      params=>{
        console.log(typeof params['isSamparkKaryakar'])
        this.mandalId = params['mandalId']
        if(params['id'] != undefined){
          // console.log(params);
          this.yuvak.id = params['id'];
          this.yuvak.name = params['name'];
          this.yuvak.dob = formatDate(params['dob'], 'yyyy-MM-dd', 'en_US');
          this.yuvak.address = params['address'];
          this.yuvak.mandalId = params['mandalId'];
          this.yuvak.mobile = params['mobile'];
          this.yuvak.education = params['education'];
          this.yuvak.email = params['email'];
          this.yuvak.samparkId = params['samparkId'];
          this.yuvak.count = params['count'];
          this.syRole = params['isSamparkKaryakar'];
        }
      }
      ) 
      this.getSamparkKaryakar(this.mandalId)
  }

  onSubmit(){
    if(this.syRole == 'true'){
      this.yuvak.isSamparkKaryakar = true
    }
    else{
      this.yuvak.isSamparkKaryakar = false
    }
    console.log(this.yuvak.id)
    if(this.yuvak.id == 0){
      console.log("Insert")
      this.yuvakServices.insertYuvak(this.yuvak)
        .subscribe(
          response => {
            console.log(response)
          }
        );
    }
    else{
      console.log("Update")
      this.updateProfile()
    }
  }

  updateProfile(){
    this.yuvakServices.updateYuvak(this.yuvak)
      .subscribe(
        response => {
          console.log(response);
        }
      );
  }

  getSamparkKaryakar(mandalId: number){
    this.yuvakServices.getSamparkKaryakar(mandalId)
      .subscribe(
        response => {
          this.samparkKaryakars = response;
          console.log(response);
        }
      )
  }
}
