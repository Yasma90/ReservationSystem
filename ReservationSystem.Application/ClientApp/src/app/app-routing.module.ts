import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactCreateComponent } from './components/contact-create/contact-create.component';
import { ReservationCreateComponent } from './components/reservation-create/reservation-create.component';
import { ReservationListComponent } from './components/reservation-list/reservation-list.component';

const routes: Routes = [
  { path: '', component: ReservationListComponent},
  { path: 'reservations', component: ReservationListComponent},
  { path: 'reservations/create', component: ReservationCreateComponent},
  { path: 'reservations/edit/:id', component: ReservationCreateComponent},
  { path: 'contacts/create', component: ContactCreateComponent },
  { path: 'contacts/edit/:id', component: ContactCreateComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
