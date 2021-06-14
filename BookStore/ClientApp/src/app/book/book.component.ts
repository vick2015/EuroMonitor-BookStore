import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../book.service';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  books : Book[];
  constructor(private bookService:BookService, private loginService: LoginService,
    private router:Router) { }

  ngOnInit() {

    if(!this.loginService.isUserLoggedIn())
    {
        this.router.navigate(["/login"]);
    }
    else
    {
      this.bookService.getAllBooks().subscribe(
        books => {
          this.books = books;
          console.log(this.books);
        });
    }

  }

}
