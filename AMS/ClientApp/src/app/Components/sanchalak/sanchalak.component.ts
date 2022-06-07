import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sanchalak',
  templateUrl: './sanchalak.component.html',
  styleUrls: ['./sanchalak.component.css']
})
export class SanchalakComponent implements OnInit {
  sabhaDate = '2019-06-29';
  t : boolean = false;
  constructor() { }

  ngOnInit(): void {
  }
  onClick(){
    this.t = true;
  }
  onClick1(date: string){
    this.sabhaDate = date;
    console.log(this.sabhaDate)
  }
}
