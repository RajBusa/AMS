import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Sabha } from 'src/app/models/sabha.modal';

@Injectable({
  providedIn: 'root'
})
export class SabhaService {

  constructor(private http: HttpClient) { }
  baseUrl = 'https://localhost:7140/api/';

  getTotalSabha(id: number): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'Sabha/getTotalSabhaByMandalId/' + id);
  }

  getUpcomingSabhaByMandalId(id: number) : Observable<Sabha[]>{
    return this.http.get<Sabha[]>(this.baseUrl + 'Sabha/getUpComingSabhaByMandalId/' + id);
  }

  updateSabha(sabha: Sabha) : Observable<Sabha>{
    return this.http.put<Sabha>(this.baseUrl + 'Sabha/updateSabha', sabha);
  }
}
