import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { GetCarResponse } from 'src/app/models/response/get-car-response.model';
import { Maker } from 'src/app/models/response/maker.model';
import { Model } from 'src/app/models/response/model.model';
import { environment } from 'src/environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class CarService {
  baseApiUrl= environment.baseApiUrl;
  constructor(private http:HttpClient) { }

  //this is an observable defined in the form of a function
  getAllCars(makerId:number=-1, modelId:number=-1, rentalPrice:number=-1):Observable<GetCarResponse[]>{
   
    let headers = new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));
    return this.http.get<GetCarResponse []>(`${this.baseApiUrl}/api/Car?makerId=${makerId}&modelId=${modelId}&rentalPrice=${rentalPrice}`,{headers})
  }

  getCar(id:string):Observable<GetCarResponse>{
    console.log("this is id",id);
    let headers = new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));
    return this.http.get<GetCarResponse>(`${this.baseApiUrl}/api/Car/${id}`,{headers})
  }


  getAllModels():Observable<Model[]>{
    let headers = new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));    
    return this.http.get<Model[]>(`${this.baseApiUrl}/api/Model`,{headers});
  }
  getModel(id:number):Observable<Model>{
    let headers = new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));
    return this.http.get<Model>(`${this.baseApiUrl}/api/Model/${id}`,{headers});
  }
  getAllMakers():Observable<Maker[]>{
    let headers = new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));    
    return this.http.get<Maker[]>(`${this.baseApiUrl}/api/Maker`,{headers});
  }
  getMaker(id:number):Observable<Maker>{
    let headers = new HttpHeaders().set('Authorization','Bearer '+ localStorage.getItem('token'));
    return this.http.get<Maker>(`${this.baseApiUrl}/api/Maker/${id}`,{headers});
  }
}
