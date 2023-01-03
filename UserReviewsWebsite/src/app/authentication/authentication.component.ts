import { Token } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserApiService } from '../user-api.service';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent implements OnInit {
  inLoginMode = true;

  constructor(private service: UserApiService, private routter: Router) { }


  onSwitchMode() {
    this.inLoginMode = !this.inLoginMode;
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    this.service.LoginUser(form.value).subscribe(
      (response: any) => {
        localStorage.setItem('token', response.token);
        this.routter.navigateByUrl('/home');
      }
    );
    form.reset();
  }


  ngOnInit(): void {
  }

}
