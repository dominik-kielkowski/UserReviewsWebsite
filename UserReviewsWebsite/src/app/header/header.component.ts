import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserApiService } from '../services/user-api.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  token: any;
  userDetails: any;

  refresh = new BehaviorSubject<boolean>(true);


  constructor(private userService: UserApiService) { }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');

    this.userService.GetUserProfile().subscribe(
      res => {
        this.userDetails = res
      }
    )

  }

  onLogout() {
    localStorage.removeItem('token');
    window.location.reload();
  }

}
