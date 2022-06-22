import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Karyakar } from 'src/app/models/karyakar.model';
import { Sampark } from 'src/app/models/Sampark';
import { SamparkKaryakar } from 'src/app/models/samparkKaryakar.model';
import { SignIn } from 'src/app/models/signIn.model';

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
    // console.log(Karyakarid)
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

  getKaryakarByEmailId(email: string): Observable<Karyakar[]>{
    return this.http.post<Karyakar[]>(this.baseUrl + 'Karyakar/getKaryakarByEmailId', email);
  }

  getAllYuvakAndSK(id: number): Observable<Sampark[]> {
    return this.http.get<Sampark[]>(this.baseUrl+'Karyakar/GetAllYuvaks/'+id)
  }

  getKaryakar(id: number): Observable<Karyakar[]> {
    return this.http.get<Karyakar[]>(this.baseUrl+'Karyakar/'+id)
  }

  newSamparkKaryakar(yId:number[]) : Observable<number> {
    // console.log(yId)
    return this.http.post<number>(this.baseUrl + 'Karyakar/insertKaryakarFromYuvakId/', yId);
  }

  login(signIn: SignIn) : Observable<number> {
    return this.http.put<number>(this.baseUrl+ 'Karyakar/SignIn', signIn);
  }
  signUp(user: SignIn) : Observable<number> {
    return this.http.put<number>(this.baseUrl+ 'Karyakar/changePassword', user);
  }
}
