import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { CreateAgreementRequest } from 'src/app/models/request/create-agreement-request.model';
import { UpdateAgreementRequest } from 'src/app/models/request/update-agreement-request.model';
import { GetAgreementResponse } from 'src/app/models/response/get-agreement-response.model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AgreementService {
  baseApiUrl= environment.baseApiUrl;
  constructor(private http:HttpClient) { }
  
  getAllAgreements():Observable<GetAgreementResponse[]>{
    //creates a new HttpHeaders object and sets the Authorization header to the bearer token stored in local storage.
    // The bearer token is a type of authentication token that is used to authorize access to protected resources.
    let headers = new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));
    return this.http.get<GetAgreementResponse[]>(`${this.baseApiUrl}/api/Agreement`,{headers});
  }
  getAgreement(id:string):Observable<GetAgreementResponse>{
    let headers = new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));
    return this.http.get<GetAgreementResponse>(`${this.baseApiUrl}/api/Agreement/${id}`,{headers});
  }
  addAgreement(agreement:CreateAgreementRequest):Observable<any>{
    let headers= new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));
    return this.http.post(`${this.baseApiUrl}/api/Agreement`,agreement,{headers});
  }
  updateAgreement(agreement:UpdateAgreementRequest, id:string):Observable<any>{
    let headers= new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));
    return this.http.put(`${this.baseApiUrl}/api/Agreement/${id}`,agreement,{headers});
  }
  handleReturnRequest(request:any, id:string):Observable<any> {
    let headers= new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));
    return this.http.put(`${this.baseApiUrl}/api/Agreement/return-request/${id}`,request,{headers});
  }
  removeAgreement(id:string):Observable<any>{
    let headers = new HttpHeaders().set('Authorization','Bearer ' + localStorage.getItem('token'));
    return this.http.delete(`${this.baseApiUrl}/api/Agreement/${id}`);
  }
  getUserAgreements():Observable<any>{
    let headers = new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));
    return this.http.get(`${this.baseApiUrl}/api/Agreement/user-agreements`,{headers});
  }
  
}
