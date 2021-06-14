import { Component, OnInit } from '@angular/core';
import { order } from '../Models/Order';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  orders: order[];
  constructor(private orderservice: OrderService) { }

  ngOnInit() {
    this.getAllOrdersForUser();
  }

  getAllOrdersForUser() {
    var userid = localStorage.getItem('userId');
    this.orderservice.getAllOrdersFromUser(userid).subscribe(orders => {
      this.orders = orders;
      console.log(this.orders);
    })

}

}

