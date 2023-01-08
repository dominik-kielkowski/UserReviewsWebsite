import { Component, OnInit } from '@angular/core';
import { UserApiService } from '../user-api.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  token: any;
  userDetails: any;


  constructor(private userService: UserApiService) { }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');
    console.log(this.token)

    this.userService.GetUserProfile().subscribe(
      res => {
        console.log(res)
        this.userDetails = res
      },
      err => {
        console.log(err);
      }
    )
  }

  onLogout() {
    localStorage.removeItem('token');
  }

}
