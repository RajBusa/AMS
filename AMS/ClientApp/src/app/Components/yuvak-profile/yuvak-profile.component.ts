import { Component, OnInit} from '@angular/core';
import { Yuvak } from 'src/app/models/yuvak.model';
import { ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-yuvak-profile',
  templateUrl: './yuvak-profile.component.html',
  styleUrls: ['./yuvak-profile.component.css']
})
export class YuvakProfileComponent implements OnInit {

  yuvak :Yuvak = {
    id: 1,
    name: 'Raj',
    dob: '2002-06-02',
    address: 'Nadiad',
    mobile: '9909876457',
    education: 'IT',
    email: 'raj@gmail.com',
    mandalId: 1,
    samparkId: 1,
    count: 1
  };
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params=>{
        console.log(params);
        this.yuvak.id = params['id'];
        this.yuvak.name = params['name'];
        // formatDate(new Date(), 'yyyy-MM-dd', 'en_US')
        this.yuvak.dob = formatDate(params['dob'], 'yyyy-MM-dd', 'en_US');
        this.yuvak.address = params['address'];
        this.yuvak.mandalId = params['mandalId'];
        this.yuvak.mobile = params['mobile'];
        this.yuvak.education = params['education'];
        this.yuvak.email = params['email'];
        this.yuvak.samparkId = params['samparkId'];
        this.yuvak.count = params['count'];

      }
    ) 
  }

}
