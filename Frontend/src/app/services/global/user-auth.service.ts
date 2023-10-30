import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {
  baseApiUrl = environment.baseApiUrl;
  constructor(private http:HttpClient) { }

  login(loginDetail:any):Observable<object>{
    return this.http.post<object>(`${this.baseApiUrl}/api/Auth/Login`,loginDetail);
  }

  roleMatch(allowedRoles:string[]): boolean {
    var isMatch = false;
    var tokenObj =localStorage.getItem('token');
    if(tokenObj!=null){
      var payLoad = JSON.parse(window.atob(tokenObj.split('.')[1]));
    }
    var userRole = payLoad.role;

    allowedRoles.forEach(element=> {
      if (userRole == element) {
        isMatch = true;
        return false;
      }
      else{
        return true;
      }
    });
    return isMatch;
  }

}
