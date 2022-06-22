import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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
    // console.log(yuvak.samparkId);
    return this.http.post<Yuvak>(this.baseUrl + 'Yuvak', yuvak);
  }

  updateIsAttendanceTaken(id:number,data:boolean) : Observable<number> {
    return this.http.put<number>(this.baseUrl + 'Yuvak/UpdateYuvakAttendance/'+id,data);
  }
  
  changesOfYuvak(sId:number, yId: number[]) : Observable<number> {
    // console.log(sId)
    // console.log(yId)
    return this.http.put<number>(this.baseUrl + 'Yuvak/updateSamparkidOfYuvak/'+sId,yId);
  }
}