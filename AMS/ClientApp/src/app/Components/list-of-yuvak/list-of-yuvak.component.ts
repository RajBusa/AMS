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
  constructor(private yuvakServices: YuvakService) { }

  ngOnInit(): void {
    this.getAllYuvak();
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

}