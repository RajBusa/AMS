import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SabhaAttendance } from 'src/app/models/sabhaAttendance.model';

@Injectable({
  providedIn: 'root'
})
export class SabhaAttendanceService {

  constructor(private http: HttpClient) { }
  baseUrl = 'https://localhost:7140/api/';

  ExitisingAttendance(yid:number,sid:number) : Observable<number>{
    return this.http.get<number>(this.baseUrl + 'SabhaAttendance/'+yid+'/'+sid);
  }

  DeleteAttendance(yid:number,sid:number) : Observable<number>{
    return this.http.delete<number>(this.baseUrl + 'SabhaAttendance/'+yid+'/'+sid);
  }

  insertSabhaAttendance(sabhaAttendance: SabhaAttendance) : Observable<number>{
    // console.log("insertSabhaAttendance")
    // console.table(sabhaAttendance)
    return this.http.post<number>(this.baseUrl + 'SabhaAttendance', sabhaAttendance);
  }
}
