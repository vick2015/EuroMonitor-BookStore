import { Component, Input, OnInit } from '@angular/core';
import { BookService } from '../book.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {

  @Input()
  book : Book

  @Input()
  BookId : string

  constructor(private bookService : BookService) { }

  ngOnInit() {
  }

 ngOnChanges()
 {
  console.log(this.BookId);

   if(this.BookId == undefined || this.BookId == null)
   {
     return;
   }

   this.bookService.getBookById(this.BookId).subscribe(book => {
     this.book = book;
   })
   
 }

}
