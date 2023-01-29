import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/User.model';
import { UserApiService } from 'src/app/services/user-api.service';

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

      const user: User = {
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
