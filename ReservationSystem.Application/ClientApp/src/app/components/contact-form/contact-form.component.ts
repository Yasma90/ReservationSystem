import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Subject, takeUntil } from 'rxjs';
import { Contact } from 'src/app/models/contact';
import { ContactType } from 'src/app/models/contact-type';
import { ContactTypeService } from 'src/app/services/contact-type.service';
import { ContactService } from 'src/app/services/contact.service';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {

  @Output()
    contactChange: EventEmitter<Contact> = new EventEmitter<Contact>();

  public form: FormGroup;
  contact: Contact= new Contact();
  contactTypes: ContactType[];
  date = new FormControl(new Date());
  maxDate: Date;
  searchContact: boolean;

  protected ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(
    private service: ContactService,
    private contactTypeService: ContactTypeService,
    private formBuilder: FormBuilder,
    private toast: ToastrService) {
      this.maxDate = new Date();
  }

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
    if(this.contact?.id){
      this.form.patchValue(this.contact);
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

  searchByName(){
    this.searchContact = true;
    this.ngUnsubscribe.next();
    this.service.getContactByName(this.form.get('name').value)
    .pipe(takeUntil(this.ngUnsubscribe))
    .subscribe(
      resp => {
        //if(resp != undefined){
        const contact = resp as Contact;
        //this.setAbstractControl(contact);
        this.setFormGroup(contact);
        this.ngUnsubscribe.next();
        this.searchContact = false;
        //}
        //else {
        //  this.contact.id = null;
        //  this.form.get('id').setValue('');
        //}
      },
      err => {
        this.ngUnsubscribe.next();
        this.searchContact = false;
        //this.form.reset();
      }
    );

  }

  //**Function Help */

  setFormGroup(contact: Contact){
    this.form.controls['id'].setValue(contact?.id);
    this.form.controls['name'].setValue(contact?.name);
    this.form.controls['birthDate'].setValue(contact?.birthDate);
    this.form.controls['phoneNumber'].setValue(contact?.phoneNumber);
    this.form.controls['contactTypeId'].setValue(contact?.contactTypeId);
  }

  parseContact() {
    this.contact.id = this.form.contains['id'];
    this.contact.name = this.form.contains['name'];
    this.contact.phoneNumber = this.form.contains['phoneNumber'];
    this.contact.birthDate = this.form.contains['birthDate'];
    this.contact.contactTypeId = this.form.contains['contactTypeId'];
  }

  isValid(): boolean{
    return this.form.valid;
  }

}
