
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { LoginService } from '../login.service';
import { user } from '../Models/User';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  public errorMessage: string = '';
  public showError: boolean;
  private _returnUrl: string;

  constructor(private _authService: LoginService, private _router: Router, private _route: ActivatedRoute) { }

  ngOnInit(): void {

    if(this._authService.isUserLoggedIn())
    {
      this._authService.logoutUser();
    }

    this.loginForm = new FormGroup({
      username: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    })

    this._returnUrl = this._route.snapshot.queryParams['returnUrl'] || '/';
  }

  public validateControl = (controlName: string) => {
    return this.loginForm.controls[controlName].invalid && this.loginForm.controls[controlName].touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.loginForm.controls[controlName].hasError(errorName)
  }

  public loginUser = (loginFormValue) => {
    this.showError = false;
    const login = {... loginFormValue };
    const userForAuth: user = {
      email: login.username,
      password: login.password
    }

    this._authService.login(userForAuth)
    .subscribe(res => {
       localStorage.setItem('token', res.token);
       localStorage.setItem('userId',res.userId)
       this._router.navigate([this._returnUrl]);
    });
  }
}