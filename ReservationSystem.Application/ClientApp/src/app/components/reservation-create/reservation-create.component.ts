import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { errorsResponseApi } from 'src/app/helpers/utilities/utilities';
import { Contact } from 'src/app/models/contact';
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

  @ViewChild(ContactFormComponent)
    contactForm: ContactFormComponent;

  @Input() errors: string[] = [];
  formGroup: FormGroup;
  contact: Contact= new Contact();
  reservation: Reservation=new Reservation();
  id?: string;

  cheked: boolean;
  minDate: Date;
  myFilter = (d: Date | null): boolean => {
    const day = (d || new Date()).getDate  //getDay();
    // Prevent Saturday and Sunday from being selected.
    //return day !== 0 && day !== 6;
    return day <= Date.now;
  };

  constructor(
    public service: ReservationService,
    private contactService: ContactService,
    private actRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService) {
      this.formGroup = this.formBuilder.group({
        id: [null],
        description: ['', Validators.required],
        date: ['', Validators.required],
        contactId: [null],
        contact: [null]
      });
      this.minDate = new Date();
     }

  ngOnInit(): void {

    this.actRoute.params.subscribe(params => {
      this.id = params['id'];
    });
    if(this.id){
      this.service.getReservationById(this.id)
      .subscribe(
        resp=> {
          this.reservation = resp as Reservation
          this.formGroup.patchValue(this.reservation);
          this.contactForm.setFormGroup(this.reservation?.contact);
          //this.formGroup.get('description').setValue(this.reservation.description);
          this.contact = resp.contact;
        }
      );
    }
    else{
      this.toastrService.info("ReservationId is null")
    }
  }

  contactChange(contact: Contact){
    if(contact != undefined){
      this.formGroup.get('contact').setValue(contact);
    }
  }

  //* Reservation Services *//
  onnSubmit(): void{
    if (!this.formGroup.valid){
      this.toastrService.error('Form not valid');
      return;
    }
    this.toastrService.success(`INTO ONSUBMIT: ${this.id}` );
    this.id != undefined ? this.AddReservations(): this.EditReservation();
  }

  AddReservations(){
    this.service.postReservation(this.formGroup.value as Reservation)
    .subscribe(
      () => {
        this.resetForm();
        this.toastrService.success('Added successfully', 'Reservation register');
      },
      err => {
        console.log(err); //this.errors = errorsResponseApi(err);
        this.toastrService.error(`Error adding reservation: ${err}`);
      })
    }

  EditReservation(){
    this.service.putReservation(this.formGroup.value as Reservation)
    .subscribe(
      () => {
        this.toastrService.success('Updated successfully', 'Reservation updated');
    },
      err=> {
        console.log(err); //this.errors = errorsResponseApi(err);
        this.toastrService.error(`Error adding reservation: ${err}`);
    });
  }


  resetForm(){
    this.formGroup.reset();
  }


}
