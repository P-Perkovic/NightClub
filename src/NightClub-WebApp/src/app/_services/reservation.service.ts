import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Reservation } from '../_models/Reservation';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private _baseUrl: string = environment.baseUrl + 'api/reservations/';

  constructor(private _http: HttpClient) { }

  public getAllForDate(date: Date): Observable<Reservation[]> {
    return this._http.get<Reservation[]>(this._baseUrl + date.toDateString());
  }

  public getAllForCurrentUser(): Observable<Reservation[]> {
    return this._http.get<Reservation[]>(this._baseUrl);
  }

  public getReservedDatesForUser(): Observable<Date[]> {
    return this._http.get<Date[]>(this._baseUrl + "dates");
  }

  public getAllReservedDates(): Observable<Date[]> {
    return this._http.get<Date[]>(this._baseUrl + "all-dates");
  }

  public addReservation(reservation: Reservation) {
    return this._http.post(this._baseUrl, reservation);
  }

  public cancelReservation(reservationId: number) {
    return this._http.put(this._baseUrl + "cancel/" + reservationId, {});
  }

  public cancelForDate(date: Date, note: string) {
    return this._http.put(this._baseUrl + "cancel/" + date.toDateString(), { note: note });
  }
}
