import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Yuvak } from 'src/app/models/yuvak.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  yuvak: Yuvak = {
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
    isSamparkKaryakar: false,
    isAttendanceTaken: false
  };

  constructor(private route: ActivatedRoute) { }
  
  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params => {
        // console.log(params['mandalId'])
        // console.log(typeof params['mandalId'])
        this.yuvak.name = params['name'];
        this.yuvak.dob = formatDate(params['dob'], 'yyyy-MM-dd', 'en_US');
        this.yuvak.address = params['address'];
        this.yuvak.mobile = params['mobile'];
        this.yuvak.education = params['education'];
        this.yuvak.email = params['email']; 
      })
  }

}

// DOB Education 