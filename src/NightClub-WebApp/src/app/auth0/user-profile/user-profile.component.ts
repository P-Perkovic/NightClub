import { ConfigType, ReservData } from './../../ConfigData';
import { ToastrService } from 'ngx-toastr';
import { AdminConfigService } from './../../_services/admin-config.service';
import { GlobalApp } from './../../GlobalApp';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { AdminConfig } from 'src/app/_models/AdminConfig';
import { map } from 'rxjs/operators';
import { NgModel } from '@angular/forms';
import { debug } from 'console';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  adminConfigs: AdminConfig[];

  constructor(public auth: AuthService,
    public app: GlobalApp,
    public adminService: AdminConfigService,
    public toastr: ToastrService,
    public reservData: ReservData) {
  }
  ngOnInit(): void {
    this.getConfigs();
  }

  isTypeSelectNeeded(typeName: string) {
    if ((typeName == ConfigType.Decimal) || (typeName == ConfigType.Int))
      return false;

    else
      return true;
  }

  changeValues(key: string) {
    this.adminConfigs.forEach(ac => {
      if (ac.key == key) {
        ac.values = this.reservData.getDataList(ac.typeName);
        ac.value = null;
      }
    });
  }

  updateConfig(adminConfig: AdminConfig, model: NgModel) {
    this.adminService.updateConfig(adminConfig.key, adminConfig)
      .subscribe(r => {
        this.toastr.success('The admin config has been updated.');
        model.reset(r.value);
      },
        error => {
          this.toastr.error('Failed to update the admin config.');
        });
  }

  getConfigs() {
    if (this.app.getRole() == GlobalApp.Admin) {
      this.adminService.getAdminConfigs().pipe(
        map(acs => {
          acs.forEach(ac => {
            var nameList;
            ac.name = ac.key;
            var index = ac.name.indexOf('_');
            if (index > 0)
              ac.name = ac.name.slice(0, index);
            nameList = ac.name.split(/(?=[A-Z])/);
            ac.name = '';
            nameList.forEach(e => {
              ac.name += e + ' ';
            });
            ac.values = this.reservData.getDataList(ac.typeName);
          });
          return acs;
        })
      )
        .subscribe(r => {
          this.adminConfigs = r;
        },
          error => {
            this.toastr.error('Problem with server, can not get data.');
          });
    }
  }
}
