import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Reservation } from 'src/app/models/reservation';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-reservation-item',
  templateUrl: './reservation-item.component.html',
  styleUrls: ['./reservation-item.component.css']
})
export class ReservationItemComponent implements OnInit {

  @Input() reservation: Reservation;
  isFavorite: boolean;

  constructor(
    private service: ReservationService,
    /*private toastr:ToastrService*/) { }

  ngOnInit(): void {
    this.isFavorite=this.reservation.favorite;
  }

  editReservation(reservation: Reservation){
    this.service.putReservation(reservation)
    .subscribe(()=>{},err=> console.error(err));
  }

  setFavorite(){
    this.reservation.favorite = !this.reservation.favorite;
    this.editReservation(this.reservation);
  }
}
