import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { order } from './Models/Order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private httpClient : HttpClient) { }


  getAllOrdersFromUser(userid : string) : Observable<order[]>
  {
    const reqHeader =  new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
   });

   const apiurl = `https://localhost:44337/Orders?userid=${userid}`;

      const response = this.httpClient.get<order[]>(apiurl,{headers:reqHeader})
      return response;
  }
}
