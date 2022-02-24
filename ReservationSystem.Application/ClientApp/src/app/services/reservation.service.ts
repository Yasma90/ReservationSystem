import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Reservation } from '../models/reservation';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Headers': 'Content-Type',
    'Access-Control-Allow-Methods': 'GET,POST,OPTIONS,DELETE,PUT'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  readonly baseUrl = `${environment.apiUrl}/reservations`;

  constructor( private http: HttpClient) {}

  getReservations(): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(this.baseUrl);
  }

  getReservationById(id: string): Observable<Reservation> {
    return this.http.get<Reservation>(`${this.baseUrl}/${id}`);
  }

  postReservation(reservation: Reservation): Observable<Reservation> {
    return this.http.post<Reservation>(this.baseUrl, reservation, httpOptions);
  }

  putReservation(reservation: Reservation){
    return this.http.put(`${this.baseUrl}/${reservation.id}`,reservation);
  }

  delReservation(reservation: Reservation){
    return this.http.delete(`${this.baseUrl}/${reservation.id}`);
  }

}
