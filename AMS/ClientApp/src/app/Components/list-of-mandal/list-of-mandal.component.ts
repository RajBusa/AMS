import { Component, Input, OnInit } from '@angular/core';
import { Karyakar } from 'src/app/models/karyakar.model';
import { MandalwithYuvakCount } from 'src/app/models/mandalwithYuvakCount.model';
import { MandalService } from 'src/app/Services/Mandal/mandal.service';

@Component({
  selector: 'app-list-of-mandal',
  templateUrl: './list-of-mandal.component.html',
  styleUrls: ['./list-of-mandal.component.css']
})
export class ListOfMandalComponent implements OnInit {

  @Input() karyakar!: Karyakar;
  mandalwithYuvakCount: MandalwithYuvakCount[] = [];
  searchText = '';
  val: number = 1;

  constructor(private mandalService: MandalService) { }

  ngOnInit(): void {
    if(this.karyakar.roleId == 3){
      this.getMandalWithYuvakCount(this.karyakar.id, true)
    } else if (this.karyakar.roleId == 4) {
      this.getMandalWithYuvakCount(this.karyakar.kshetraId, false)
    }
  }
  getMandalWithYuvakCount(id: number, isNirikshak: boolean){
    this.mandalService.getMandalWithYuvakCount(id, isNirikshak)
      .subscribe(
        response =>{
          // console.log(response)  
          this.mandalwithYuvakCount = response;
        }
      )
  }

}
