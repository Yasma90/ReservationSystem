import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { errorsResponseApi } from 'src/app/helpers/utilities/utilities';
import { Reservation } from 'src/app/models/reservation';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-reservation-item',
  templateUrl: './reservation-item.component.html',
  styleUrls: ['./reservation-item.component.css']
})
export class ReservationItemComponent implements OnInit {

  //@Input() errors: string[] = [];
  @Input() reservation: Reservation;
  isFavorite: boolean;

  constructor(
    private service: ReservationService,
    /*private toastr:ToastrService*/) { }

  ngOnInit(): void {
    this.isFavorite = this.reservation.favorite;
  }

  setFavorite(){
    this.reservation.favorite = !this.reservation.favorite;
    this.editReservation(this.reservation);
  }

  editReservation(reservation: Reservation){
    this.service.putReservation(reservation)
    .subscribe(() => {}, err => console.error(err));
  }

}
