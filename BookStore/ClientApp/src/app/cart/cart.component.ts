import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BookService } from '../book.service';
import { order } from '../Models/Order';
import { orderRequest } from '../Models/OrderRequest';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})


export class CartComponent implements OnInit {


  @ViewChild("content", { static: false }) 
  modalContent: TemplateRef<any>;

  @Input()
  bookId:string

order:order
display:String;

  constructor(private bookService:BookService,private modalService: NgbModal) { }

  ngOnInit() {
    console.log(this.bookId);
  }
  
  BuyBook()
  {

    const orderRequest: orderRequest = {
      bookid: this.bookId,
      userid: localStorage.getItem('userId')
    }
    this.bookService.BuyBook(orderRequest).subscribe(order => {
      this.order = order;
      this.modalService.open(this.modalContent).result.then((result) => {
       
      });
    })
  }

}
