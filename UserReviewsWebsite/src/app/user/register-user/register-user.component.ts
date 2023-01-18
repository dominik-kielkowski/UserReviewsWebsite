import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
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

  constructor(private userService: UserApiService) { }

  ngOnInit(): void {
  }

  onSubmit() {

    var user = {
      Username: this.username,
      Email: this.email,
      PasswordHash: this.passwordHash,
      RoleId: this.roleId,
    }
    

    this.userService.RegisterUser(user).subscribe()
    console.log(user)
  }

}
