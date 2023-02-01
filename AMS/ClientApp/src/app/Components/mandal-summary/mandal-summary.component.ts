import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MandalService } from 'src/app/Services/Mandal/mandal.service';

@Component({
  selector: 'app-mandal-summary',
  templateUrl: './mandal-summary.component.html',
  styleUrls: ['./mandal-summary.component.css']
})
export class MandalSummaryComponent implements OnInit {
  constructor(private route: ActivatedRoute, private mandalService: MandalService) { }

  mandalId?: number;
  mandalName?: string;
  karyakarName?: string;
  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params => {
        this.mandalId = params["mandalId"];
        this.karyakarName = params["karyakarName"];
        console.log(this.mandalId)
        this.mandalService.getMandalName(this.mandalId!).subscribe(
          response => {
            this.mandalName = response;
          }
          
        )
      }
    )
  }

}
