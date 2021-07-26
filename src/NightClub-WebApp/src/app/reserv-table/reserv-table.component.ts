import { GlobalApp } from './../GlobalApp';
import { ToastrService } from 'ngx-toastr';
import { TableService } from './../_services/table.service';
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

  constructor(public resService: ReservationService,
    public tableService: TableService,
    private toastr: ToastrService,
    private reservData: ReservData,
    public app: GlobalApp) { }

  ngOnInit(): void {
    this.resetReservation();
  }

  setDate($event) {
    this.date = new Date($event.year, $event.month, $event.day);
    this.resService.getAllForDate(this.date)
      .subscribe(r => {
        this.reservations = r;
        this.resetReservation();
        this.isTablesDisabled = false;
        setTimeout(() => {
          window.scrollTo($('#tables').position())
          var hover = $(document).find('.hover');
          hover.css('fill', '');
          hover.removeClass('hover');
        }, 0);
      },
        error => {
          this.toastr.error(GlobalApp.ServerError);
        });
  }

  setTable($event) {
    this.table = $event;
    var allowed = this.reservData.getDataList(ConfigType.Int);
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
  }

  reserve() {
    var reservation = new Reservation();
    reservation.tableId = this.table.id;
    reservation.dateOfReservation = this.date;
    reservation.numberOfGuests = Number.parseInt(this.numberOfGuests);
    reservation.reservedFor = this.reservedFor;
    reservation.note = this.note;

    this.resService.addReservation(reservation)
      .subscribe(r => {
        this.toastr.success('The table has been reserved.')
        this.resetReservation();
      },
        error => {
          this.toastr.error('Failed to reserve the table.');
        });
  }
}