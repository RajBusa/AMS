import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MandalKaryakar } from 'src/app/models/mandalKaryakar.model';

@Injectable({
  providedIn: 'root'
})
export class MandalKaryakarService {

  constructor(private http: HttpClient) { }
  baseUrl = 'https://localhost:7140/api/';


  insertMandalKarykar(mandalKaryakar: MandalKaryakar): Observable<number>{
    return this.http.post<number>(this.baseUrl + 'MandalKaryakar', mandalKaryakar);
  }

  deleteMandalKaryakar(Karyakarid: number): Observable<number>{
    // console.log(Karyakarid)
    return this.http.delete<number>(this.baseUrl + 'MandalKaryakar/' + Karyakarid);
  } 
}
