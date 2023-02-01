import { Component, OnInit ,Input} from '@angular/core';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent implements OnInit {
  @Input() name!: string;
  @Input() Role!: string;
  @Input() mandal!: string;
  
  constructor() { }
  // @Input() karyakar!: Karyakar;
  ngOnInit(): void {
    
  }
}
