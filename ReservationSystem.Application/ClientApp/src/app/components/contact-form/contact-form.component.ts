import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Contact } from 'src/app/models/contact';
import { ContactType } from 'src/app/models/contact-type';
import { ContactTypeService } from 'src/app/services/contact-type.service';
import { ContactService } from 'src/app/services/contact.service';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {

  @Output()
    contactChange: EventEmitter<Contact> = new EventEmitter<Contact>();

  form: FormGroup;
  contact: Contact;
  contactTypes: ContactType[];
  date = new FormControl(new Date());
  maxDate: Date;

  constructor(
    private contactTypeService: ContactTypeService,
    private formBuilder: FormBuilder,
    private toast: ToastrService) {
      this.maxDate = new Date();
  }

    //*OnInit*//
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      contactTypeId: ['', Validators.required],
      birthDate: ['', Validators.required],
      phoneNumber: ['', { Validators: [
                  Validators.required,
                  Validators.pattern('^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$')]
      }]
    });
    this.getContactTypes();

    //if(this.contact?.id)
    if(this.contact?.id){
      //this.form.reset();
      this.setFormGroup(this.contact);
      //this.form.patchValue(this.contact);
    }

  }

  //**Rise the event send the data back to parent*//
  sendContactForm(){
    this.parseContact();
    this.contactChange.emit(this.contact);
  }

  //*Services*//
  getContactTypes(){
    this.contactTypeService.getContactTypes()
    .subscribe( resp => this.contactTypes = resp);
  }

  //**Function Help */
  parseContact(){
    this.contact.name = this.form.contains['name'];
    this.contact.phoneNumber = this.form.contains['phoneNumber'];
    this.contact.birthDate = this.form.contains['birthDate'];
    this.contact.contactTypeId = this.form.contains['contactTypeId'];
  }

  setFormGroup(contact: Contact){
    this.form.get('name').setValue(contact?.name);
    this.form.get('birthDate').setValue(contact?.birthDate);
    this.form.get('phoneNumber').setValue(contact?.phoneNumber);
    this.form.get('contactTypeId').setValue(contact?.contactTypeId);
  }

}
