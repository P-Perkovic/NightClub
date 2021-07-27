import { ConfirmationDialogService } from './../../_services/confirmation-dialog.service';
import { ReservationService } from './../../_services/reservation.service';
import { ConfigType, ReservData } from './../../ConfigData';
import { ToastrService } from 'ngx-toastr';
import { AdminConfigService } from './../../_services/admin-config.service';
import { GlobalApp } from './../../GlobalApp';
import { Component, OnInit } from '@angular/core';
import { AdminConfig } from 'src/app/_models/AdminConfig';
import { map } from 'rxjs/operators';
import { NgModel } from '@angular/forms';
import { Reservation } from 'src/app/_models/Reservation';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  adminConfigs: AdminConfig[];
  reservations: Reservation[];
  reservDates: string[] = new Array<string>();
  date: string;
  note: string;

  constructor(private _adminService: AdminConfigService,
    private _toastr: ToastrService,
    private _reservData: ReservData,
    private _resService: ReservationService,
    private _confirmationDialogService: ConfirmationDialogService,
    public app: GlobalApp,
    public auth: AuthService) {
  }
  ngOnInit(): void {
    if (this.app.getRole() == GlobalApp.Admin) {
      this.getReservedDates();
      this.getConfigs();
    }
    else {
      this.getReservations();
    }
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
        ac.values = this._reservData.getDataList(ac.typeName);
        ac.value = null;
      }
    });
  }

  updateConfig(adminConfig: AdminConfig, model: NgModel) {
    this._adminService.updateConfig(adminConfig.key, adminConfig)
      .subscribe(r => {
        this._toastr.success('The admin config has been updated.');
        model.reset(r.value);
      },
        error => {
          this._toastr.error('Failed to update the admin config.');
        });
  }

  getConfigs() {
    if (this.app.getRole() == GlobalApp.Admin) {
      this._adminService.getAdminConfigs().pipe(
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
            ac.values = this._reservData.getDataList(ac.typeName);
          });
          return acs;
        })
      )
        .subscribe(r => {
          this.adminConfigs = r;
        },
          error => {
            this._toastr.error('Problem with server, can not get data.');
          });
    }
  }

  getReservations() {
    this._resService.getAllForCurrentUser()
      .subscribe(r => {
        this.reservations = r;
      });
  }

  getReservedDates() {
    this._resService.getAllReservedDates()
      .subscribe(r => {
        r.forEach(d => {
          var dateString = d.toString();
          this.reservDates.push(dateString.slice(0, dateString.indexOf('T')));
        });
        this.date = this.reservDates[0];
        this.getReservationsForDate();
      });
  }

  getReservationsForDate() {
    var dateArray = this.date.split('-');
    var date = new Date(Number.parseInt(dateArray[0]), Number.parseInt(dateArray[1]), Number.parseInt(dateArray[2]));
    this._resService.getAllForDate(date)
      .subscribe(r => {
        this.reservations = r;
      });
  }

  cancelAll() {
    var dateArray = this.date.split('-');
    var date = new Date(Number.parseInt(dateArray[0]), Number.parseInt(dateArray[1]), Number.parseInt(dateArray[2]));
    this._confirmationDialogService.confirm('Atention', 'Do you really want to cancel all reservations?', 'Cancel', 'Go Back')
      .then(() =>
        this._resService.cancelForDate(date, this.note)
          .subscribe(r => {
            this.reservDates = new Array<string>();
            this.getReservedDates();
            this._toastr.success('Reservations has been canceled.')
          },
            error => {
              this._toastr.error('Failed to cancel reservations.');
            }))
      .catch(() => '');
  }

  cancel(id: number) {
    this._confirmationDialogService.confirm('Atention', 'Do you really want to cancel the reservation?', 'Cancel', 'Go Back')
      .then(() =>
        this._resService.cancelReservation(id)
          .subscribe(r => {
            this.getReservations();
            this._toastr.success('The Reservation has been canceled.')
          },
            error => {
              this._toastr.error('Failed to cancel reservations.');
            }))
      .catch(() => '');
  }

  seeNote(note: string) {
    this._confirmationDialogService.confirm('Note', note, '', 'Ok');
  }
}
