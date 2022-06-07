import { DatePipe, formatDate, getLocaleDateFormat, getLocaleDateTimeFormat } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Sabha } from 'src/app/models/sabha.modal';
import { Yuvak } from 'src/app/models/yuvak.model';
import { YuvakService } from 'src/app/Services/Yuvak/yuvak.service';

@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css']
})
export class AttendanceComponent implements OnInit {

  mandalId: number = 1;
  isMandal: boolean = true;
  yuvak: Yuvak[] = [];
  sabha: Sabha[] = [];
  searchText: string = '';
  sahbadate: Date = new Date();
  constructor(private yuvakServices: YuvakService) { }


  ngOnInit(): void {
    this.getAllYuvak(this.mandalId, this.isMandal);
    this.getSabha(this.mandalId)
  }


  getAllYuvak(mandalId: number, isMandal: boolean) {
    this.yuvakServices.getAllYuvak(mandalId, isMandal)
      .subscribe(
        response => {
          this.yuvak = response;
          // console.table(response);
        }
      );
  }

  getSabha(mandalId: number){
    this.yuvakServices.getUpcomingSabhaByMandalId(mandalId)
      .subscribe(
        response => {
          this.sabha = response;
          this.sahbadate = response[0].sabhaDate;
          console.table(response[0].sabhaDate)
        }
      )
  }

  onSubmit(){
    console.log(typeof this.sahbadate)
    this.sabha[0].sabhaDate = new Date(this.sahbadate);
    // this.sabha[0].sabhaDate = ;
    console.log(this.sabha[0].sabhaDate);
    this.yuvakServices.updateSabha(this.sabha[0]);
  }
}
