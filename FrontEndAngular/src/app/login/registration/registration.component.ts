import { UserService } from './../../services/user.service';
import { AlertService } from './../../services/alert.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  model: any = {};
  loading = false;


  constructor(
    private router: Router,
        private userService: UserService,
        private alertService: AlertService) { }

  register() {
    this.loading = true;
    this.userService.create(this.model)
        .subscribe(
          data => {
            this.alertService.success('Registration successful', true);
            this.router.navigate(['/login']);
          },
          error => {
              this.alertService.error(error._body);
              this.loading = false;
          });
  }

}
