import { ToastrService } from 'ngx-toastr';
import { Table } from './../_models/Table';
import { TableService } from './../_services/table.service';
import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { Reservation } from '../_models/Reservation';
import { GlobalApp } from '../GlobalApp';
declare var $: JQueryStatic;

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.css']
})
export class TablesComponent implements OnInit {
  tables: Table[];
  @Output() tableChanged = new EventEmitter<Table>();
  @Input() isDisabled: boolean;
  @Input() reservations: Reservation[];

  constructor(private _tableService: TableService,
    private _toastr: ToastrService) { }

  ngOnInit(): void {
    this._tableService.getTables()
      .subscribe(r => {
        this.tables = r;
        this.jQuery();
      },
        error => {
          this._toastr.error(GlobalApp.ServerError);
        });
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes.reservations.currentValue != changes.reservations.previousValue) {
      this.resetTables();
      this.mapTables();
      this.setDisabled();
    }
  }

  setTable(id: string, component: any) {
    var table = component.tables.find(t => t.ordinalNumber.toString() == id)
    component.tableChanged.emit(table);
  }

  resetTables() {
    this.tables.forEach(r => {
      r.isDisabled = false;
    });
  }

  mapTables() {
    this.tables.forEach(t => {
      if (this.reservations.find(r => r.table.id == t.id)) {
        t.isDisabled = true;
      }
    });
  }

  setDisabled() {
    var disabled = $(document).find('.disabled');
    disabled.css('fill', '');
    disabled.removeClass('disabled');
    this.tables.forEach(t => {
      if (t.isDisabled) {
        $('#r' + t.ordinalNumber).addClass('disabled');
      }
    });
  }

  jQuery() {
    let component = this;
    let setTable = this.setTable;
    let id;
    $('.tables text').hover(function () {
      if (component.isDisabled)
        return;
      id = this.id;
      $('#r' + id).css('fill', 'rgb(13, 37, 255)');
      $('#r' + id).addClass('hover');
    });

    $('.tables rect').hover(function () {
      if (component.isDisabled)
        return;
      id = this.id.replace('r', '');
      $('#r' + id).css('fill', 'rgb(13, 37, 255)');
      $('#r' + id).addClass('hover');
    });

    $('.tables text').click(function () {
      if (component.isDisabled)
        return;
      id = this.id;
      if ($('#r' + id).attr('class').includes('disabled'))
        return;

      setChosen(id);
    });

    $('.tables rect').click(function () {
      if (component.isDisabled)
        return;
      id = this.id.replace('r', '');
      if ($('#r' + id).attr('class').includes('disabled'))
        return;

      setChosen(id);
    });

    $('.tables text').mouseleave(function () {
      id = this.id.replace('r', '');
      if ($('#r' + id).attr('class').includes('chosen'))
        return;
      $('#r' + id).css('fill', '');
      $('#r' + id).removeClass('hover');
    });

    $('.tables rect').mouseleave(function () {
      id = this.id.replace('r', '');
      if ($('#r' + id).attr('class').includes('chosen'))
        return;
      $('#r' + id).css('fill', '');
      $('#r' + id).removeClass('hover');
    });

    function setChosen(id) {
      setTable(id, component);
      let chosen = $(document).find('.chosen');
      chosen.css('fill', '');
      chosen.removeClass('chosen');

      $('#r' + id).css('fill', 'rgb(13, 37, 255)');
      $('#r' + id).addClass('chosen');
    }
  }
}
