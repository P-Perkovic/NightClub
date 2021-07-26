import { GlobalApp } from './../GlobalApp';
import { ToastrService } from 'ngx-toastr';
import { ReservationService } from './../_services/reservation.service';
import { ConfigKey } from './../ConfigData';
import { AdminConfigService } from './../_services/admin-config.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgbCalendar, NgbDate, NgbDateParserFormatter, NgbDateStruct, NgbPeriod } from '@ng-bootstrap/ng-bootstrap';
import { NgModel } from '@angular/forms';

@Component({
    selector: 'ngbd-datepicker-popup',
    templateUrl: './datepicker-popup.html'
})

export class NgbdDatepickerPopup implements OnInit {
    date: NgbDate;
    oldDate: NgbDate;
    fromDate: NgbDateStruct;
    toDate: NgbDateStruct;
    disabledDates: NgbDateStruct[] = new Array<NgbDateStruct>();

    @Input() placeholder: string;
    @Output() dateChanged = new EventEmitter<NgbDate>();

    constructor(public calendar: NgbCalendar,
        private adminConfig: AdminConfigService,
        public formatter: NgbDateParserFormatter,
        private reserv: ReservationService,
        public toastr: ToastrService,
        public app: GlobalApp) { }

    ngOnInit(): void {
        this.adminConfig.getAdminConfigByKey(ConfigKey.ReservationPeriod.toString())
            .subscribe(r => {
                var period = <NgbPeriod>r.typeName[0].toLowerCase();
                var value = Number.parseInt(r.value);
                this.fromDate = this.calendar.getToday();
                this.toDate = this.calendar.getNext(this.calendar.getToday(), period, value);
            },
                error => {
                    this.toastr.error(GlobalApp.ServerError);
                });

        this.reserv.getReservedDatesForUser()
            .subscribe(r => {
                r.forEach(d => {
                    this.disabledDates.push(this.formatter.parse(d.toString()));
                });
            },
                error => {
                    this.toastr.error(GlobalApp.ServerError);
                });
    }

    isDisabled = (date: NgbDate) => this.disabledDates.findIndex(d => date.equals(d)) != -1;

    onChange(model: NgModel) {
        if (this.checkDate(model.value)) {
            setTimeout(() => {
                if (!(this.date.year == model.value.year &&
                    this.date.month == model.value.month &&
                    this.date.day == model.value.day)) {
                    return;
                }
                if (!model.valid) {
                    this.oldDate = model.value;
                    model.reset();
                    this.toastr.warning("This date is disabled!");
                }
                else if (model.valid)
                    this.dateChanged.emit(model.value);
            }, 1000);
        }
    }

    checkDate(date: NgbDate): boolean {
        if (date.day != undefined)
            return true;

        return false;
    }
}