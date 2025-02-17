import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../services/auth.service';
import { LoginRequest } from '../../models/login-request';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  credentials: LoginRequest = {
    email: '',
    password: ''
  }

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.isLoggedIn();
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  login(): void {
    this.authService.login(this.credentials).subscribe(() => {
      console.log('User is logged in');
    })
  }
}
