import { Component, OnInit, Input} from '@angular/core';
import { Karyakar } from 'src/app/models/karyakar.model';
import { Yuvak } from 'src/app/models/yuvak.model';
import { MandalKaryakarService } from 'src/app/Services/MandalKaryakar/mandal-karyakar.service';
import { SabhaService } from 'src/app/Services/Sabha/sabha.service';
import { YuvakService } from 'src/app/Services/Yuvak/yuvak.service';
@Component({
  selector: 'app-list-of-yuvak',
  templateUrl: './list-of-yuvak.component.html',
  styleUrls: ['./list-of-yuvak.component.css']
})
export class ListOfYuvakComponent implements OnInit { 

  @Input() karyakar!: Karyakar;
  
  yuvaks: Yuvak[] = [];
  samparkId: number = 1;
  mandalId: number = 0;
  isMandal?: boolean;
  totalSabha: number = 0;
  filter: string = "Descending";
  searchText = '';
  // roleId: number = 2;

  
  constructor(private yuvakServices: YuvakService, private sabhaServices: SabhaService, private mandalKaryakarService: MandalKaryakarService) { }
  ngOnInit() {
    if(history.state.mandalId != undefined){
      this.isMandal = true;
      this.mandalId = history.state.mandalId;
      sessionStorage.setItem("mandalId",history.state.mandalId)
      this.getAllYuvak(this.mandalId, this.isMandal);
      this.getTotalSabha();
      this.sortYuvak();
      console.log(this.mandalId)
    } else if(sessionStorage.getItem('mandalId') != null) {
      this.mandalId = parseInt(sessionStorage.getItem('mandalId')!);
      this.getAllYuvak(this.mandalId, this.isMandal!);
      this.getTotalSabha();
      this.sortYuvak();
    } else {
      if(this.karyakar.roleId == 1) {
       this.isMandal = false;
      }
      this.getMandalId();
    }
    // console.log(this.karyakar);
  }

  getAllYuvak(samparkId: number, isMandal: boolean) {
    this.yuvakServices.getAllYuvak(samparkId, isMandal)
      .subscribe(
        response => {
          this.yuvaks = response;
          // console.table(response[0].isSamparkKaryakar);
        }
      );
  }
  
  sortYuvak(){
    if(this.filter == "Accending"){
      this.yuvaks = this.yuvaks.sort((a:Yuvak, b:Yuvak)=> (a.count < b.count) ? -1 : 1 );
      this.filter = "Descending";
    }
    else{
      this.yuvaks = this.yuvaks.sort((a:Yuvak, b:Yuvak)=> (a.count > b.count) ? -1 : 1 );
      this.filter = "Accending";
    }

    // console.table(this.yuvak);
  }

  getTotalSabha(){
    this.sabhaServices.getTotalSabha(this.mandalId)
      .subscribe(
        response => {
          this.totalSabha = response;
        }
      );
  }

  getMandalId(){
    this.mandalKaryakarService.getMandalId(this.karyakar.id)
      .subscribe(
        response => {
          console.log(response)
          this.mandalId = response[0];
          console.log(this.mandalId)
          this.getAllYuvak(this.karyakar.id, this.isMandal!);
          this.getTotalSabha();
          this.sortYuvak();
        }
      )
  }

  calculateStuff(count: number){
    if(count === this.totalSabha){
      return 10;
    }
    let a = 100 - (count/this.totalSabha) * 100;  
    if((a <= 100 && a > 75)){
      return 100;
    }
    else if((a <= 75 && a > 50)){
      return 75;
    }else if((a <= 50 && a > 25)){
      return 50;
    }else if((a <= 25 && a > 10)){
      return 25;
    }else{
      return 10;
    }
  }
}