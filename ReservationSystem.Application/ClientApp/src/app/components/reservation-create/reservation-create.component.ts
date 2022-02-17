import { Component, Input, OnInit } from '@angular/core';
import { errorsResponseApi } from 'src/app/helpers/utilities/utilities';
import { Reservation } from 'src/app/models/reservation';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-reservation-create',
  templateUrl: './reservation-create.component.html',
  styleUrls: ['./reservation-create.component.css']
})
export class ReservationCreateComponent implements OnInit {

  @Input()
  errors: string[] = [];

  constructor( private service: ReservationService) { }

  ngOnInit(): void {
  }

  save(reservation: Reservation){
    this.service.postReservation(reservation).subscribe(
      () => {},
      err=> this.errors= errorsResponseApi(err))
  }

}
