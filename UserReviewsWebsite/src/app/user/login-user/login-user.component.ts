import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserApiService } from 'src/app/services/user-api.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {
  inLoginMode = true;
  error: any;

  constructor(private service: UserApiService, private router: Router) { }

  onSubmit(form: NgForm) {
    this.service.LoginUser(form.value).subscribe(
      res => {
        localStorage.setItem('token', res.token);
        form.reset();
        window.location.reload();
      },
      error => {
        this.error = error.error.title
        console.log(error)
      }
    );
  }


  ngOnInit(): void {
  }

}
