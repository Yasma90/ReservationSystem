import { Component, Input, OnInit } from '@angular/core';
import { Reservation } from 'src/app/models/reservation';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-reservation-list',
  templateUrl: './reservation-list.component.html',
  styleUrls: ['./reservation-list.component.css']
})
export class ReservationListComponent implements OnInit {
  reservations: Reservation[] = [];
  @Input()
  reservationId: string;

  constructor(
    public service: ReservationService) { }

  ngOnInit(): void {
    this.getReservations();
  }

  getReservations(){
    this.service.getReservations()
    .subscribe( resp => this.reservations = resp);
  }

  delete(reservation: Reservation){
    this.service.delReservation(reservation)
    .subscribe(()=>{},err=> console.error(err));
  }

}
