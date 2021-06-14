import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { order } from './Models/Order';
import { orderRequest } from './Models/OrderRequest';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private apiUrl = "https://localhost:44337/Books";
  constructor(private httpClient: HttpClient) { 
   
  }

  getAllBooks() : Observable<Book[]>
  {
    const reqHeader =  new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
   });

      const url = this.apiUrl + "/GetAllBooks";
      const response = this.httpClient.get<Book[]>(url,{headers:reqHeader})
      return response;
  }

  getBookById(bookId:string) : Observable<Book>
  {
    const reqHeader =  new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
   });

      const url = this.apiUrl + `/GetBooksById?bookId=${bookId}`;
      const response = this.httpClient.get<Book>(url,{headers:reqHeader})
      return response;
  }

  BuyBook(orderRequest:orderRequest) : Observable<order>
  {

    const ordersApiUrl = "https://localhost:44337/Orders";
    const reqHeader =  new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
   });

   const response = this.httpClient.post<order>(ordersApiUrl,orderRequest,{headers:reqHeader})

   return response;
  }

  }