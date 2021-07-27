import { Router } from '@angular/router';
import { GlobalApp } from 'src/app/GlobalApp';
import { ToastrService } from 'ngx-toastr';
import { ReservationService } from './../_services/reservation.service';
import { Component, OnInit } from '@angular/core';
import { Table } from '../_models/Table';
import { Reservation } from '../_models/Reservation';
import { ConfigType, ReservData } from '../ConfigData';
declare var $: JQueryStatic;

@Component({
  selector: 'app-reserv-table',
  templateUrl: './reserv-table.component.html',
  styleUrls: ['./reserv-table.component.css']
})
export class ReservTableComponent implements OnInit {
  table: Table;
  numberOfGuests: string;
  allowedNumberOfGuests: string[];
  reservedFor: string = '';
  note: string = '';
  reservations: Reservation[] = null;
  date: Date;
  isTablesDisabled: boolean = true;

  constructor(private _resService: ReservationService,
    private _toastr: ToastrService,
    private _reservData: ReservData,
    public app: GlobalApp,
    private _router: Router) { }

  ngOnInit(): void {
    this.resetReservation();
  }

  setDate($event) {
    this.date = new Date($event.year, $event.month, $event.day);
    this.resetReservation();
    this.getReservations();
    this.isTablesDisabled = false;
  }

  setTable($event) {
    this.table = $event;
    var allowed = this._reservData.getDataList(ConfigType.Int);
    this.allowedNumberOfGuests = allowed.slice(0, allowed.findIndex(a =>
      a == this.table.category.maxNumberOfGuests.toString()) + 1);
    setTimeout(() => {
      window.scrollTo($('#table').position())
    }, 0);
  }

  resetReservation() {
    this.table = {
      id: null,
      ordinalNumber: null,
      category: {
        name: "",
        minBillValue: null,
        maxNumberOfGuests: null
      },
      isDisabled: false
    }
    this.numberOfGuests = null;
    this.reservedFor = '';
    this.note = '';

    setTimeout(() => {
      var chosen = $(document).find('.chosen');
      chosen.css('fill', '');
      chosen.removeClass('chosen');
    }, 0);
  }

  reserve() {
    var reservation = new Reservation();
    reservation.tableId = this.table.id;
    reservation.dateOfReservation = this.date;
    reservation.numberOfGuests = Number.parseInt(this.numberOfGuests);
    reservation.reservedFor = this.reservedFor;
    reservation.note = this.note;

    this._resService.addReservation(reservation)
      .subscribe(r => {
        this._toastr.success('The table has been reserved.')
        if (this.app.getRole() == GlobalApp.Admin) {
          this.resetReservation();
          this.getReservations();
        }
        else {
          this._router.navigate(['/user/']);
        }

      },
        error => {
          this._toastr.error('Failed to reserve the table.');
        });
  }
  getReservations() {
    this._resService.getAllForDate(this.date)
      .subscribe(r => {
        this.reservations = r;
        setTimeout(() => {
          window.scrollTo($('#tables').position())
          var hover = $(document).find('.hover');
          hover.css('fill', '');
          hover.removeClass('hover');
        }, 0);
      },
        error => {
          this._toastr.error(GlobalApp.ServerError);
        });
  }
}