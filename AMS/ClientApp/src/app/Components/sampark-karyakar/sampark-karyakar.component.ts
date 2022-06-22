import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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

  str: String = '';
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      // console.log(params['samparkKaryakar']);
      this.samparkKaryakar = JSON.parse(params["samparkKaryakar"])
      console.log(this.samparkKaryakar)
    })
  }
}