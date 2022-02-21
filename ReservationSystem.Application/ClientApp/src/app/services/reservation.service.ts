import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Reservation } from '../models/reservation';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  readonly baseUrl = `${environment.apiUrl}/reservations`;

  formData: Reservation = new Reservation();
  list: Reservation[];

  constructor(
    private http: HttpClient) {}


  getList(){
    this.http.get(this.baseUrl)
     .toPromise()
     .then(resp=>this.list = resp as Reservation[]);
  }

  getReservations(): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(this.baseUrl);
  }

  getById(id: string): void {
    this.http.get<Reservation>(`${this.baseUrl}/${id}`)
    .toPromise()
    .then(resp => this.formData = resp as Reservation);
  }

  getReservationById(id: string): Observable<Reservation> {
    return this.http.get<Reservation>(`${this.baseUrl}/${id}`);
  }

  add(){
    return this.http.post(this.baseUrl,this.formData);
  }

  postReservation(reservation: Reservation) {
    return this.http.post(this.baseUrl, reservation);
  }

  update(){
    return this.http.put(`${this.baseUrl}/${this.formData.id}`,this.formData);
  }

  putReservation(reservation: Reservation){
    return this.http.put(`${this.baseUrl}/${reservation.id}`,reservation);
  }

  delete(){
    return this.http.delete(`${this.baseUrl}/${this.formData.id}`);
  }

  delReservation(reservation: Reservation){
    return this.http.delete(`${this.baseUrl}/${reservation.id}`);
  }

}
