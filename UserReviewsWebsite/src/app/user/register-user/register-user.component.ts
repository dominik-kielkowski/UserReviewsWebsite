import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserApiService } from 'src/app/user-api.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

  constructor(private userService: UserApiService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    this.userService.RegisterUser(form.value).subscribe()
  }

}
