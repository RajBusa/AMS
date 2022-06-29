import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-mandal-summary',
  templateUrl: './mandal-summary.component.html',
  styleUrls: ['./mandal-summary.component.css']
})
export class MandalSummaryComponent implements OnInit {
  constructor(private route: ActivatedRoute) { }

  mandalId?: number;
  mandalName?: string;
  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params => {
        this.mandalId = params["mandalId"];
        this.mandalName = params["mandalName"];
        console.log(this.mandalId)
      }
    )
  }

}
