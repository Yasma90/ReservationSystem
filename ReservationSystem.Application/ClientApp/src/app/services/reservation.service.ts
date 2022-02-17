import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Reservation } from '../models/reservation';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  constructor(
    private http: HttpClient) {}

  readonly baseUrl = `${environment.apiUrl}/reservations`;

  getReservations(): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(this.baseUrl);
  }

  getReservationById(id: string): Observable<Reservation> {
    return this.http.get<Reservation>(`${this.baseUrl}/${id}`);
  }

  postReservation(reservation: Reservation) {
    return this.http.post(this.baseUrl, reservation);
  }

  putReservation(reservation: Reservation){
    return this.http.put(`${this.baseUrl}/${reservation.id}`,reservation);
  }

  delReservation(reservation: Reservation){
    return this.http.delete(`${this.baseUrl}/${reservation.id}`);
  }

}
