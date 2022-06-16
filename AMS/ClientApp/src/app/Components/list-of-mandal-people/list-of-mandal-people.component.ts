import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Karyakar } from 'src/app/models/karyakar.model';
import { Yuvak } from 'src/app/models/yuvak.model';
import { KaryakarService } from 'src/app/Services/Karyakar/karyakar.service';
import { YuvakService } from 'src/app/Services/Yuvak/yuvak.service';

@Component({
  selector: 'app-list-of-mandal-people',
  templateUrl: './list-of-mandal-people.component.html',
  styleUrls: ['./list-of-mandal-people.component.css']
})
export class ListOfMandalPeopleComponent implements OnInit {
  yuvaks: Yuvak[] = [];
  sanchalak: Karyakar[] = [];
  mandalId: number = 0;
  mandalName?: string;
  searchText: string = '';
  constructor(private route: ActivatedRoute, private yuvakServices: YuvakService, private karyakarService: KaryakarService) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params => {
        // console.log(params['mandalId'])
        // console.log(typeof params['mandalId'])
        this.mandalId = params['mandalId']
        this.mandalName = params['mandalName']
        this.getAllYuvak(this.mandalId, true);
        this.getAllSanchalak(this.mandalId)
      })
  }
  getAllYuvak(mandalId: number, isMandal: boolean) {
    this.yuvakServices.getAllYuvak(mandalId, isMandal)
      .subscribe(
        response => {
          this.yuvaks = response;
          // console.table(response);
          this.yuvaks = response;
          // console.table(this.yuvaks)
        }
      );
  }

  getAllSanchalak(mandalId: number){
    this.karyakarService.getSanchlak(mandalId)
      .subscribe(
        response => {
          this.sanchalak = response;
          console.log(this.sanchalak);
        }
      )
  }

  

}
