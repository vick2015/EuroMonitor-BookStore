import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { user, usertoken } from './Models/User';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiUrl = "https://localhost:44337/Login";
  constructor(private httpClient: HttpClient) { }

  login(body:user) : Observable<usertoken>
  {
    return this.httpClient.post<usertoken>(this.apiUrl,body);
  }

  isUserLoggedIn()
  {
    const token = localStorage.getItem('token');
    if(token === "" || token === undefined || token == null)
    {
      return false;
    }
    return true;
  }

  logoutUser() {
    localStorage.removeItem('token');
  };
}
