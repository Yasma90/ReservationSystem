import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
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

  reservation: Reservation = new Reservation();
  contact: Contact = new Contact();
  id?: string;

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
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      id: [null],
      description: ['', Validators.required],
      date: ['', Validators.required],
      contactId: [null],
      contact: [null]
    });

    //Get Id parameter by the route.
    this.actRoute.params.subscribe(params => {
      this.id = params['id'];
    });
    if(this.id) {
      this.service.getReservationById(this.id)
      .subscribe(
        resp=> {
          this.reservation = resp as Reservation
          this.contact = this.reservation?.contact;
          this.formGroup.patchValue(this.reservation);
          this.contactForm.setFormGroup(this.contact);
        }
      );
    }
    else {
      console.info('Create Reservation');
      this.minDate = new Date();
    }
  }

  onSubmit(): void{
    if (!this.formGroup.valid && !this.contactForm.isValid()){
      console.log('Form invalid');
      return;
    }
    this.reservation.date = this.formGroup.get('date').value;
    this.reservation.description = this.formGroup.get('description').value;

    this.contact.name = this.contactForm.form.get('name').value;
    this.contact.birthDate = this.contactForm.form.get('birthDate').value;
    this.contact.phoneNumber = this.contactForm.form.get('phoneNumber').value;
    this.contact.contactTypeId = this.contactForm.form.get('contactTypeId').value;

    this.handleContact();
    if(this.id != undefined)
      this.EditReservation();
    else
      this.AddReservations()
  }

  handleContact(){
    this.contact?.id != undefined ?
      this.editContact():
      this.addContact();
  }


  //* Contact Services *//

  addContact(){
    this.contactService.postContact(this.contact)
    .subscribe(
      (resp) => {
        this.contact.id = resp.id;
        this.reservation.contactId = resp.id;
        this.reservation.contact = this.contact;
        this.toastrService.success('Contact added successfully')
      },
      err => {
        console.log(err);
        this.toastrService.error('Occurred a error', 'Contact');
        //this.errors = errorsResponseApi(err);
      }
      );
  }

  editContact(){
    this.contactService.putContact(this.contact)
    .subscribe( ()=>{
      this.toastrService.success('Contact updated successfully')
    },
    err=> {
      console.log(err)
      this.toastrService.error('Occurred a error', 'Contact')
    }
    );
  }


  //* Reservation Services *//

  AddReservations() {
    this.service.postReservation(this.reservation)
    .subscribe(
      () => {
        this.resetForm();
        this.toastrService.success('Added successfully', 'Reservation register');
      },
      err => {
        console.error(err);
        this.toastrService.error('Occurred a error', 'Reservation')
        //this.errors = errorsResponseApi(err);
      })
    }

  EditReservation(){
    this.service.putReservation(this.reservation)
    .subscribe(
      () => {
        this.toastrService.success('Updated successfully', 'Reservation updated');
    },
      err => {
        console.error(err);
        this.toastrService.error('Occurred a error', 'Reservation')
        //this.errors = errorsResponseApi(err);
    });
  }

  resetForm(){
    this.formGroup.reset();
  }


}
