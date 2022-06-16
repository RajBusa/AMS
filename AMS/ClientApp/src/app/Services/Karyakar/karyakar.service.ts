import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Karyakar } from 'src/app/models/karyakar.model';
import { SamparkKaryakar } from 'src/app/models/samparkKaryakar.model';

@Injectable({
  providedIn: 'root'
})
export class KaryakarService {

  constructor(private http: HttpClient) { }
  baseUrl = 'https://localhost:7140/api/'

  insertSamparkKaryakar(samparkKaryakar: SamparkKaryakar): Observable<number[]>{
    return this.http.post<number[]>(this.baseUrl + 'Karyakar', samparkKaryakar)
  } 

  deleteKaryakar(Karyakarid: number): Observable<number>{
    console.log(Karyakarid)
    return this.http.delete<number>(this.baseUrl + 'Karyakar/' + Karyakarid);
  } 

  updateSamparkKaryakar(samparkKaryakar: Karyakar): Observable<number>{
    // console.log(samparkKaryakar);
    return this.http.put<number>(this.baseUrl + 'Karyakar', samparkKaryakar)
  }
  
  getSamparkKaryakar(mId: number) : Observable<SamparkKaryakar[]>{
    // console.log(mId)
    return this.http.get<SamparkKaryakar[]>(this.baseUrl + 'Karyakar/getSamparkKaryakar/' + mId);
  }

  getSanchlak(mId: number) : Observable<Karyakar[]>{
    // console.log(mId)
    return this.http.get<Karyakar[]>(this.baseUrl + 'Karyakar/getSanchalak/' + mId);
  }
}
