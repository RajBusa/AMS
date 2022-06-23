import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MandalwithYuvakCount } from 'src/app/models/mandalwithYuvakCount.model';

@Injectable({
  providedIn: 'root'
})
export class MandalService {

  constructor(private http: HttpClient) { }
  baseUrl = 'https://localhost:7140/api/';
  getMandalWithYuvakCount(id: number, isNirikshak: boolean): Observable<MandalwithYuvakCount[]> {
    return this.http.get<MandalwithYuvakCount[]>(this.baseUrl + 'Nirikshak/' + id + '/' + isNirikshak);
  }
}
