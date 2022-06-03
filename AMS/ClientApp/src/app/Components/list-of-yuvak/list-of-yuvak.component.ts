import { Component, OnInit } from '@angular/core';
import { Yuvak } from 'src/app/models/yuvak.model';
import { YuvakService } from 'src/app/Services/Yuvak/yuvak.service';

@Component({
  selector: 'app-list-of-yuvak',
  templateUrl: './list-of-yuvak.component.html',
  styleUrls: ['./list-of-yuvak.component.css']
})
export class ListOfYuvakComponent implements OnInit { 
  yuvak: Yuvak[] = [];
  // num?: number;
  totalSabha?: number;
  constructor(private yuvakServices: YuvakService) { }
  searchText = '';
  ngOnInit(): void {
    this.getAllYuvak();
    this.getTotalSabha();
  }

  getAllYuvak() {
    this.yuvakServices.getAllYuvak(1)
      .subscribe(
        response => {
          this.yuvak = response;
          console.table(response);
        }
      );
  }
  
  getTotalSabha(){
    this.yuvakServices.getTotalSabha(1)
      .subscribe(
        response => {
          this.totalSabha = response;
        }
      );
  }

}