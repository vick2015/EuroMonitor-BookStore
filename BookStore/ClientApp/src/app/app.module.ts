import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BookComponent } from './book/book.component';
import { CartComponent } from './cart/cart.component';
import { LoginComponent } from './login/login.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OrderComponent } from './order/order.component';
import { BookDetailsComponent } from './book-details/book-details.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    BookComponent,
    BookDetailsComponent,
    CartComponent,
    LoginComponent,
    OrderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: BookComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent, pathMatch: 'full' },
      { path: 'orders', component: OrderComponent, pathMatch: 'full' },

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
