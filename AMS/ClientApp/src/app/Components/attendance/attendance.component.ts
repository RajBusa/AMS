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
  changeSabhaDate: string = '';
  isAttendaanceTaken?: number;
 
  //0 means Not Taken And 1 means Taken
  todayDate: string = formatDate(new Date(), 'yyyy-MM-dd', 'en_US');
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
          this.sabha[0].sabhaDate = formatDate(this.sabha[0].sabhaDate, 'yyyy-MM-dd', 'en_US')
          console.table(this.sabha[0])
        }
      )
  }

  onSubmit(){
    // formatDate(new Date(), 'yyyy-MM-dd', 'en_US')
    this.sabha[0].sabhaDate = formatDate(this.changeSabhaDate, 'yyyy-MM-dd', 'en_US');
    console.log(this.sabha[0].sabhaDate);
    this.yuvakServices.updateSabha(this.sabha[0])
      .subscribe(
        response => {
          console.log(response)
        }
      ) 
  }


  takeAttendace(yid: number) {
    console.log(yid);
    this.yuvakServices.ExitisingAttendance(yid, this.sabha[0].id).subscribe(response => {
      this.isAttendaanceTaken = response;
      this.actionAttendace(yid);
    })
  }
  
  actionAttendace(yid: number) {
    if (this.isAttendaanceTaken == 0) {
      //Insert 
    }
    else {
      //Delete
      this.yuvakServices.DeleteAttendance(yid,this.sabha[0].id).subscribe(response => {
        console.log(response);
        console.log("Deleted");
      })
    }
  }
}