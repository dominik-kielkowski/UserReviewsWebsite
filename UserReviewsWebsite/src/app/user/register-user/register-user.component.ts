import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserApiService } from 'src/app/services/user-api.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  public user: User = {
    Username: '',
    Email: '',
    PasswordHash: '',
    RoleId: 1
  };
  
  error?: Error;

  constructor(private userService: UserApiService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit() {

      const user: User = {
      Username: this.user.Username,
      Email: this.user.Email,
      PasswordHash: this.user.PasswordHash,
      RoleId: this.user.RoleId,
    }
    console.log(user)
    console.log(this.user)


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
