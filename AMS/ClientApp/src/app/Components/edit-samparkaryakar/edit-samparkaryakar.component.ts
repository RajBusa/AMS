import { Component, OnInit } from '@angular/core';
import { YuvakService } from 'src/app/Services/Yuvak/yuvak.service';
import { Sampark } from 'src/app/models/Sampark';


@Component({
  selector: 'app-edit-samparkaryakar',
  templateUrl: './edit-samparkaryakar.component.html',
  styleUrls: ['./edit-samparkaryakar.component.css']
})
export class EditSamparkaryakarComponent implements OnInit {

  constructor(private yuvakServices: YuvakService) { }
  mandalId: number = 1;
  data: Sampark[] = [];
  ngOnInit(): void {
    this.getAllYuvaks(this.mandalId);
  }

   getAllYuvaks(mandalId: number) {
    this.yuvakServices.getAllYuvakAndSK(mandalId)
      .subscribe(
        response => {
          // console.table(this.sabha[0])
          this.data = response;
          console.log(this.data);
        }
      )
  }
}
