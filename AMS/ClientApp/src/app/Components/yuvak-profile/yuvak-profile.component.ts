import { Component, OnInit} from '@angular/core';
import { Yuvak } from 'src/app/models/yuvak.model';
import { ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';
import { YuvakService } from 'src/app/Services/Yuvak/yuvak.service';
import { SamparkKaryakar } from 'src/app/models/samparkKaryakar.model';

import { Karyakar } from 'src/app/models/karyakar.model';
import { __await } from 'tslib';
import { MandalKaryakar } from 'src/app/models/mandalKaryakar.model';


@Component({
  selector: 'app-yuvak-profile',
  templateUrl: './yuvak-profile.component.html',
  styleUrls: ['./yuvak-profile.component.css']
})
export class YuvakProfileComponent implements OnInit {
  samparkKaryakars: SamparkKaryakar[] = [];
  syRole?: string;
  mandalId: number = 0 ;
  kshetraId: number = 1;

  yuvak :Yuvak = {
    id: 0,
    name: '',
    dob: '  ',
    address: '',
    mobile: '',
    education: '',
    email: '',
    mandalId: 1,
    samparkId: 2,
    count: 1,
    isSamparkKaryakar: false
  };

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
    isActivated: false
  }

  mandalKaryakar: MandalKaryakar = {
    id: 0,
    mandalId: 0,
    karyakarId: 0  
  };

  constructor(private route: ActivatedRoute, private yuvakServices: YuvakService) { }

  ngOnInit(): void {

    this.route.queryParams.subscribe(
      params=>{
        // console.log(typeof params['isSamparkKaryakar'])
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
          console.log(params['samparkId']);
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
    console.log("InSide Function")
    if(this.yuvak.id == 0){
      if(this.yuvak.isSamparkKaryakar == false){
        this.insertYuvak();
      }
      else{
        this.insertSamparkKaryakar(); 
      }
      // console.log("Insert")
      
    }
    else{
      // console.log("Update")
      if(this.yuvak.isSamparkKaryakar == false){
        this.updateYuvakProfile()
      }
      else{
        this.updateYuvakProfile()

        this.samparkKaryakar.id = this.yuvak.samparkId 
        this.samparkKaryakar.address = this.yuvak.address
        this.samparkKaryakar.dob = this.yuvak.dob
        this.samparkKaryakar.education=this.yuvak.education
        this.samparkKaryakar.email=this.yuvak.email
        this.samparkKaryakar.karayakarNo = 0
        this.samparkKaryakar.kshetraId = this.kshetraId
        this.samparkKaryakar.mobileNo = this.yuvak.mobile
        this.samparkKaryakar.name = this.yuvak.name
        


        this.yuvakServices.updateSamparkKaryakar(this.samparkKaryakar)
          .subscribe(
            response => {
              console.log(response)
            }
          )
      }
    }
  }

  insertSamparkKaryakar() {
    this.samparkKaryakar.address = this.yuvak.address
    this.samparkKaryakar.dob = this.yuvak.dob
    this.samparkKaryakar.education=this.yuvak.education
    this.samparkKaryakar.email=this.yuvak.email
    this.samparkKaryakar.karayakarNo = 0
    this.samparkKaryakar.kshetraId = this.kshetraId
    this.samparkKaryakar.mobileNo = this.yuvak.mobile
    this.samparkKaryakar.name = this.yuvak.name

    this.mandalKaryakar.mandalId = this.yuvak.mandalId;

    this.yuvakServices.insertSamparkKaryakar(this.samparkKaryakar)
          .subscribe(
            response => {
              console.log(response[0])
              console.log(typeof response)
              console.log(typeof response[0])
              console.log(typeof this.yuvak.samparkId)
              this.yuvak.samparkId = response[0];
              this.mandalKaryakar.karyakarId = response[0];
              this.insertYuvak();
              this.InsertMandalKaryakar();
            }

          )
  }

  insertYuvak(){
    this.yuvakServices.insertYuvak(this.yuvak)
        .subscribe(
          response => {
            console.log(response)
          }
        );
  }

  InsertMandalKaryakar(){
    this.yuvakServices.insertMandalKarykar(this.mandalKaryakar)
      .subscribe(
        response => {
          console.log(response)
        }
      )
  }


  updateYuvakProfile(){
    this.yuvakServices.updateYuvak(this.yuvak)
      .subscribe(
        response => {
          // console.log(response);
        }
      );
  }

  getSamparkKaryakar(mandalId: number){
    this.yuvakServices.getSamparkKaryakar(mandalId)
      .subscribe(
        response => {
          this.samparkKaryakars = response;
          // console.log(response);
        }
      )
  }

  getSamparkId(){
    this.yuvakServices.getSamparkId()
          .subscribe(
            response => {
              console.log(response)
              // this.yuvak.samparkId = response;
            }
          )
  }
}
