import { Component, OnInit ,Input} from '@angular/core';
import { Karyakar } from 'src/app/models/karyakar.model';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent implements OnInit {

  constructor() { }
  @Input() karyakar!: Karyakar;
  ngOnInit(): void {
    
  }
}
