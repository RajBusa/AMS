import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Karyakar } from 'src/app/models/karyakar.model';

@Component({
  selector: 'app-sanchalak',
  templateUrl: './sanchalak.component.html',
  styleUrls: ['./sanchalak.component.css']
})
export class SanchalakComponent implements OnInit {
  sabhaDate = '2019-06-29';
  t : boolean = false;
  constructor(private route: ActivatedRoute) { }
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
    this.route.queryParams.subscribe(params => {
      // console.log(params['sanchalak']);
      this.sanchalak = JSON.parse(params["sanchalak"])
      // console.log(this.sanchalak)
    })
  }
  onClick(){
    this.t = true;
  }
  onClick1(date: string){
    this.sabhaDate = date;
    // console.log(this.sabhaDate)
  }
}