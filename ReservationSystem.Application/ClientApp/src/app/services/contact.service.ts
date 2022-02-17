import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Contact } from '../models/contact';


@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(
    private http: HttpClient) {}

  readonly baseUrl = `${environment.apiUrl}/contacs`;

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.baseUrl);
  }

  getContactById(id: string): Observable<Contact> {
    return this.http.get<Contact>(`${this.baseUrl}/${id}`);
  }

  postContact(contact: Contact) {
    return this.http.post(this.baseUrl,contact);
  }

  putContact(contact: Contact){
    return this.http.put(`${this.baseUrl}/${contact.id}`,contact);
  }

  delContact(contact: Contact){
    return this.http.delete(`${this.baseUrl}/${contact.id}`);
  }

}
