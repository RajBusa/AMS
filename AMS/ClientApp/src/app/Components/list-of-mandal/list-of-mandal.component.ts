import { Component, OnInit } from '@angular/core';
import { MandalwithYuvakCount } from 'src/app/models/mandalwithYuvakCount.model';
import { MandalService } from 'src/app/Services/Mandal/mandal.service';

@Component({
  selector: 'app-list-of-mandal',
  templateUrl: './list-of-mandal.component.html',
  styleUrls: ['./list-of-mandal.component.css']
})
export class ListOfMandalComponent implements OnInit {
  mandalwithYuvakCount: MandalwithYuvakCount[] = [];



  constructor(private mandalService: MandalService) { }

  ngOnInit(): void {
    this.getMandalWithYuvakCount(3)
  }
  getMandalWithYuvakCount(id: number){
    this.mandalService.getMandalWithYuvakCount(id)
      .subscribe(
        response =>{
          // console.log(response)  
          this.mandalwithYuvakCount = response;
        }
      )
  }

}
