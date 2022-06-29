import { Component, OnInit } from '@angular/core';
import { YuvakService } from 'src/app/Services/Yuvak/yuvak.service';
import { Sampark } from 'src/app/models/Sampark';
import { KaryakarService } from 'src/app/Services/Karyakar/karyakar.service';
import { SamparkKaryakar } from 'src/app/models/samparkKaryakar.model';
import { ActivatedRoute } from '@angular/router';



@Component({
  selector: 'app-edit-samparkaryakar',
  templateUrl: './edit-samparkaryakar.component.html',
  styleUrls: ['./edit-samparkaryakar.component.css']
})
export class EditSamparkaryakarComponent implements OnInit {

  constructor(private yuvakServices: YuvakService,private karyakarService: KaryakarService, private route: ActivatedRoute) { }
  mandalId?: number;
  samparkKaryakars: SamparkKaryakar[] = [];
  data: Sampark[] = [];
  yuvakList: number[] = [];
  btnDisable: boolean = false;
  fristPage: boolean = true;
  yName: string = '';
  sName: string = '';
  yId: number = 0;
  sId: number = 0;
  ngOnInit(): void {
    this.route.queryParams.subscribe(
        params => {
          this.mandalId = params["mandalId"];
          this.getAllYuvaks(this.mandalId!);
        }
    )
  }

   getAllYuvaks(mandalId: number) {
    this.karyakarService.getAllYuvakAndSK(mandalId)
      .subscribe(
        response => {
          // console.table(this.sabha[0])
          this.data = response;
          // console.log(this.data);
        }
    )
   }
  tooglePage() {
    this.fristPage = false;
    this.getSamparkKaryakar(this.mandalId!);
   }
  doAction() {
    document.getElementById('hi' + this.yId)?.click();
  }
  toogleIntoList(yId: number, yName: string, sName: string) {
    this.yName = yName;
    this.sName = sName;
    this.yId = yId;
    // document.getElementById('hi' + yId).click();
    var exit = this.yuvakList.includes(yId);
    if (exit) {
      var index = this.yuvakList.indexOf(yId);
      this.yuvakList.splice(index,1);
    }
    else {
      document.getElementById('ShowAlert')?.click();
      this.yuvakList.push(yId);
    }
    // console.log(this.yuvakList);
    if (this.yuvakList.length>0) {
      this.btnDisable = true;
    }
    else {
      this.btnDisable = false;
    }
  }
  setSkId(sId:number) {
    this.sId = sId;
  }
  getSamparkKaryakar(mandalId: number) {
    this.karyakarService.getSamparkKaryakar(mandalId)
      .subscribe(
        response => {
          this.samparkKaryakars = response;
          // console.log(this.samparkKaryakars);
        }
      )
  }

  changesOfYuvak() {
    this.yuvakServices.changesOfYuvak(this.sId, this.yuvakList)
      .subscribe(
        response => {
          // console.log(response)
        }
      )
  }

  newSamparkKaryakar(){
    this.karyakarService.newSamparkKaryakar(this.yuvakList)
      .subscribe(
        response => {
          // console.log(response);
        }
      )
  }

}
