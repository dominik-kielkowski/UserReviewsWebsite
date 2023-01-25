import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserApiService } from 'src/app/user-api.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  username = "";
  email = "";
  passwordHash = "";
  roleId = 1;
  error: any;

  constructor(private userService: UserApiService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit() {

    var user = {
      Username: this.username,
      Email: this.email,
      PasswordHash: this.passwordHash,
      RoleId: this.roleId,
    }


    this.userService.RegisterUser(user).subscribe(
      res => {
        console.log(user)
        this.router.navigate(['/home'])
      },
      error => {
        console.log(error)
        this.error = error.error.title
      })
  }
}
