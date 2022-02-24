import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Contact } from 'src/app/models/contact';
import { ContactType } from 'src/app/models/contact-type';
import { ContactTypeService } from 'src/app/services/contact-type.service';
import { ContactService } from 'src/app/services/contact.service';

@Component({
  selector: 'app-contact-create',
  templateUrl: './contact-create.component.html',
  styleUrls: ['./contact-create.component.css']
})
export class ContactCreateComponent implements OnInit {
  now: Date = new Date();
  types: ContactType[]= [];
  form!: FormGroup;

  constructor(
    public service: ContactService,
    public ContactTypeservice: ContactTypeService,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getContactTypes();
    this.form = this.formBuilder.group({
      name:['', Validators.required],
      birthDate: [new Date().toISOString(), Validators.required],
      contactType: ['', Validators.required]
    });
  }



  //*Services*/

  getContactTypes(){
    this.ContactTypeservice.getContactTypes()
    .subscribe(resp=> this.types = resp,
      err=> console.error(err));
    }

  addContact(contact: Contact){
    this.service.postContact(contact)
    .subscribe(()=>{},err=> console.error(err));
  }

  updateReservation(contact: Contact){
    this.service.putContact(contact)
    .subscribe(()=>{},err=> console.error(err));
  }

  searchByName(){
    this.service.getContactByName(this.form.get('name').value)
    .subscribe(
      resp => {
        this.form.get('id').setValue(resp.birthDate);
        this.form.get('name').setValue(resp.name);
        this.form.get('birthDate').setValue(resp.birthDate);
        this.form.get('phoneNumber').setValue(resp.phoneNumber);
        this.form.get('contactTypeId').setValue(resp.contactTypeId);
      }
    )
  }

}
