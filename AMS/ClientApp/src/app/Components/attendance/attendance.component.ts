import { formatDate} from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Sabha } from 'src/app/models/sabha.modal';
import { SabhaAttendance } from 'src/app/models/sabhaAttendance.model';
import { Yuvak } from 'src/app/models/yuvak.model';
import { SabhaService } from 'src/app/Services/Sabha/sabha.service';
import { SabhaAttendanceService } from 'src/app/Services/SabhaAttendance/sabha-attendance.service';
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
  sabhaAttendance: SabhaAttendance = {
    id: 0,
    yuvakId: 3,
    sabhaId: 5,
    attendance: new Date('2022-05-04 17:00:00')
  };

  //0 means Not Taken And 1 means Taken
  todayDate: string = formatDate(new Date(), 'yyyy-MM-dd', 'en_US');
  constructor(private sabhaService: SabhaService, private sabhaAttendanceService: SabhaAttendanceService, private yuvakService: YuvakService) { }


  ngOnInit(): void {
    this.getAllYuvak(this.mandalId, this.isMandal);
    this.getSabha(this.mandalId)
  }


  getAllYuvak(mandalId: number, isMandal: boolean) {
    this.yuvakService.getAllYuvak(mandalId, isMandal)
      .subscribe(
        response => {
          this.yuvak = response;
          // console.log(response);
        }
      );
  }

  getSabha(mandalId: number) {
    this.sabhaService.getUpcomingSabhaByMandalId(mandalId)
      .subscribe(
        response => {
          this.sabha = response;
          this.sabha[0].sabhaDate = formatDate(this.sabha[0].sabhaDate, 'yyyy-MM-dd', 'en_US')
          // console.table(this.sabha[0])
        }
      )
  }

  onSubmit() {
    // formatDate(new Date(), 'yyyy-MM-dd', 'en_US')
    this.sabha[0].sabhaDate = formatDate(this.changeSabhaDate, 'yyyy-MM-dd', 'en_US');
    console.log(this.sabha[0].sabhaDate);
    this.sabhaService.updateSabha(this.sabha[0])
      .subscribe(
        response => {
          console.log(response)
        }
      )
  }


  takeAttendace(yid: number) {
    console.log(yid);
    this.sabhaAttendanceService.ExitisingAttendance(yid, this.sabha[0].id)
      .subscribe(response => {
        if (response == 0) {
          //Insert
          this.sabhaAttendance.sabhaId = this.sabha[0].id;
          this.sabhaAttendance.yuvakId = yid;
          this.sabhaAttendance.attendance = new Date()
          console.log("Insert")
          this.sabhaAttendanceService.insertSabhaAttendance(this.sabhaAttendance)
          .subscribe(response => {
            console.log(response);
          })
          this.yuvakService.updateIsAttendanceTaken(yid, true).subscribe(response => {
            console.log(response);
            this.getAllYuvak(this.mandalId, this.isMandal)
          })
        }
        else {
          //Delete
          console.log("Delete")
          this.sabhaAttendanceService.DeleteAttendance(yid, this.sabha[0].id).subscribe(response => {
            console.log(response);
            console.log("Deleted");
          })
          this.yuvakService.updateIsAttendanceTaken(yid, false).subscribe(response => {
            console.log(response);
            this.getAllYuvak(this.mandalId, this.isMandal)
          })
        }
      })
  }


}