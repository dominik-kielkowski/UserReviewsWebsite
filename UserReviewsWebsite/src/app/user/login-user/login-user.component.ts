import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserApiService } from 'src/app/user-api.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {
  inLoginMode = true;

  constructor(private service: UserApiService, private routter: Router) { }

  onSubmit(form: NgForm) {
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
