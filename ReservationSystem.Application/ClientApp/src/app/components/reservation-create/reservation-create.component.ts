import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { errorsResponseApi } from 'src/app/helpers/utilities/utilities';
import { Reservation } from 'src/app/models/reservation';
import { ContactService } from 'src/app/services/contact.service';
import { ReservationService } from 'src/app/services/reservation.service';
import { ContactFormComponent } from '../contact-form/contact-form.component';

@Component({
  selector: 'app-reservation-create',
  templateUrl: './reservation-create.component.html',
  styleUrls: ['./reservation-create.component.css']
})
export class ReservationCreateComponent implements OnInit {

  @Input() errors: string[] = [];
  formGroup: FormGroup;
  @ViewChild(ContactFormComponent) contactForm: ContactFormComponent;
  cheked: boolean;
  constructor(
    private service: ReservationService,
    private contactService: ContactService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      rteservationDate:['',Validators.required]
    });
  }

  onSubmit(): void {
    if (!this.formGroup.valid)
      return;
  }

  save(reservation: Reservation){
    this.service.postReservation(reservation).subscribe(
      () => {},
      err=> this.errors= errorsResponseApi(err))
  }

  showSuccess() {
    this.toastrService.success('Hello world!', 'Toastr fun!');
  }

  showError(){
    this.toastrService.error('everything is broken', 'Major Error', {
      timeOut: 3000,
    });
  }

}
