import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss'],
  providers:[]
})
export class LogoutComponent {
  constructor(private router: Router, private authService: AuthService) {}

  ngOnInit(): void {

    this.authService.logout();
    //this.router.navigate(['/login']);
  }
}
