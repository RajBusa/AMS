import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { Karyakar } from 'src/app/models/karyakar.model';
import { MandalKaryakar } from 'src/app/models/mandalKaryakar.model';
import { Sabha } from 'src/app/models/sabha.modal';
import { SabhaAttendance } from 'src/app/models/sabhaAttendance.model';
import { SamparkKaryakar } from 'src/app/models/samparkKaryakar.model';

import { Yuvak } from 'src/app/models/yuvak.model';

@Injectable({
  providedIn: 'root'
})
export class YuvakService {
  baseUrl = 'https://localhost:7140/api/'
  constructor(private http: HttpClient) { }

  getAllYuvak(id: number, isMandal: boolean): Observable<Yuvak[]> {
    return this.http.get<Yuvak[]>(this.baseUrl + 'Yuvak/getKaryakarById/' + id + '/' + isMandal);
  }

  updateYuvak(yuvak: Yuvak):Observable<Yuvak>{
    // console.log(yuvak)
    return this.http.put<Yuvak>(this.baseUrl + 'Yuvak', yuvak);
  }

  insertYuvak(yuvak: Yuvak): Observable<Yuvak>{
    console.log(yuvak.samparkId);
    return this.http.post<Yuvak>(this.baseUrl + 'Yuvak', yuvak);
  }

  updateIsAttendanceTaken(id:number,data:boolean) : Observable<number> {
    return this.http.put<number>(this.baseUrl + 'Yuvak/UpdateYuvakAttendance/'+id,data);
  }

  getAllYuvakAndSK(id: number): Observable<Sampark[]> {
    return this.http.get<Sampark[]>(this.baseUrl+'Karyakar/GetAllYuvaks/'+id)
  }
}