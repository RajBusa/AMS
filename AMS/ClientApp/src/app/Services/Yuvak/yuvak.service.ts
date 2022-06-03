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

  getAllYuvak(id: number): Observable<Yuvak[]>{
    return this.http.get<Yuvak[]>(this.baseUrl + 'Yuvak/getKaryakarById/' +id);
  }

  getTotalSabha(id: number): Observable<number>{
    return this.http.get<number>(this.baseUrl + 'Sabha/' +id);
  }
}
