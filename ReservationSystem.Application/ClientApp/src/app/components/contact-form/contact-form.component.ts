import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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

  @Input()
    contact!: Contact;
  form: FormGroup;
  @Output()
    contactChange: EventEmitter<Contact> = new EventEmitter<Contact>();

  contactTypes: ContactType[];
  date = new FormControl(new Date());
  maxDate: Date;

  constructor(
    private contactTypeService: ContactTypeService,
    private formBuilder: FormBuilder,
    private toast: ToastrService,) {
      this.maxDate = new Date();
    }

    //*OnInit*//
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [null],
      name: ['', Validators.required],
      contactTypeId: ['', Validators.required],
      birthDate: ['', Validators.required],
      phoneNumber: ['', Validators.pattern('^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$')]
    });
    //if(this.contact?.id)
    if(this.contact != undefined){
      //this.form.reset();
      this.form.patchValue(this.contact);
      console.log(this.form.value);
      console.log(`Contact: ${this.contact.id}`);
    }
    this.getContactTypes();
    //setTimeout(()=>{
    //  this.sendContactForm();
    //},300);

  }

  //**Rise the event send the data back to parent*//
  sendContactForm(){
    this.contactChange.emit(this.form.value);
  }

  //*Services*//
  getContactTypes(){
    this.contactTypeService.getContactTypes()
    .subscribe( resp => this.contactTypes = resp);
  }

}
