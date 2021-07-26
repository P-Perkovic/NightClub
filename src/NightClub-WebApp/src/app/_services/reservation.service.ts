import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Reservation } from '../_models/Reservation';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private baseUrl: string = environment.baseUrl + 'api/reservations/';

  constructor(private http: HttpClient) { }

  public getAllForDate(date: Date): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(this.baseUrl + date.toDateString());
  }

  public getAllForCurrentUser(): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(this.baseUrl);
  }

  public getReservedDatesForUser(): Observable<Date[]> {
    return this.http.get<Date[]>(this.baseUrl + "dates");
  }

  public addReservation(reservation: Reservation) {
    return this.http.post(this.baseUrl, reservation);
  }

  public cancelReservation(reservationId: string) {
    this.http.put(this.baseUrl + "cancel/" + reservationId, {});
  }

  public cancelForDate(date: Date) {
    this.http.put(this.baseUrl + "cancel-for-date", date);
  }
}
