import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReservationCreateComponent } from './components/reservation-create/reservation-create.component';
import { ReservationListComponent } from './components/reservation-list/reservation-list.component';

const routes: Routes = [
  {path: '', component: ReservationListComponent},
  {path: 'reservations', component: ReservationListComponent},
  {path: 'reservations/create', component: ReservationCreateComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
