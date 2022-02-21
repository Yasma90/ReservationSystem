import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
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
  @Input()
    reservation: Reservation;
  isFavorite: boolean;

  constructor(
    private service: ReservationService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
    this.isFavorite = this.reservation.favorite;
  }

  updateRanking(ranking: number){
    this.reservation.ranking = ranking;
    this.editReservation(this.reservation);
  }

  setFavorite(){
    this.reservation.favorite = !this.reservation.favorite;
    this.editReservation(this.reservation);
  }

  editReservation(reservation: Reservation){
    this.service.putReservation(reservation)
    .subscribe(
      () => this.toastr.info('Reservation updated successfully', 'Update Reservation' ), err => console.error(err));
  }

}
