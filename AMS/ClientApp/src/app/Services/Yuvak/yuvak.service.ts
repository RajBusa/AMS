import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';

import { Observable } from 'rxjs';
import { Sabha } from 'src/app/models/sabha.modal';
import { SabhaAttendance } from 'src/app/models/sabhaAttendance.model';

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

  getTotalSabha(id: number): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'Sabha/getTotalSabhaByMandalId/' + id);
  }

  getUpcomingSabhaByMandalId(id: number) : Observable<Sabha[]>{
    return this.http.get<Sabha[]>(this.baseUrl + 'Sabha/getUpComingSabhaByMandalId/' + id);
  }

  updateSabha(sabha: Sabha) : Observable<Sabha>{
    return this.http.put<Sabha>(this.baseUrl + 'Sabha/updateSabha', sabha);
  }
  
  ExitisingAttendance(yid:number,sid:number) : Observable<number>{
    return this.http.get<number>(this.baseUrl + 'SabhaAttendance/'+yid+'/'+sid);
  }
  DeleteAttendance(yid:number,sid:number) : Observable<number>{
    return this.http.delete<number>(this.baseUrl + 'SabhaAttendance/'+yid+'/'+sid);
  }

  insertSabhaAttendance(sabhaAttendance: SabhaAttendance) : Observable<number>{
    console.log("insertSabhaAttendance")
    console.table(sabhaAttendance)
    return this.http.post<number>(this.baseUrl + 'SabhaAttendance', sabhaAttendance);
  }
}