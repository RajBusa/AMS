import { Component, OnInit} from '@angular/core';
import { Yuvak } from 'src/app/models/yuvak.model';
import { SabhaService } from 'src/app/Services/Sabha/sabha.service';
import { YuvakService } from 'src/app/Services/Yuvak/yuvak.service';

@Component({
  selector: 'app-list-of-yuvak',
  templateUrl: './list-of-yuvak.component.html',
  styleUrls: ['./list-of-yuvak.component.css']
})
export class ListOfYuvakComponent implements OnInit { 
  yuvaks: Yuvak[] = [];
  samparkId: number = 1;
  mandalId: number = 1;
  isMandal: boolean = true;
  totalSabha: number = 0;
  filter: string = "Descending";
  searchText = '';
  roleId: number = 2;

  
  constructor(private yuvakServices: YuvakService, private sabhaServices: SabhaService) { }
  ngOnInit(): void {
    this.getAllYuvak(this.samparkId, this.isMandal);
    this.getTotalSabha(this.mandalId);
    this.sortYuvak();
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

  getTotalSabha(mandalId: number){
    this.sabhaServices.getTotalSabha(mandalId)
      .subscribe(
        response => {
          this.totalSabha = response;
        }
      );
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