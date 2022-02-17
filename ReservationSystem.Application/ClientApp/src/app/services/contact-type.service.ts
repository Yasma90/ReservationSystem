import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ContactType } from '../models/contact-type';

@Injectable({
  providedIn: 'root'
})
export class ContactTypeService {

  constructor(
    private http: HttpClient) {}

  readonly baseUrl = `${environment.apiUrl}/contactTypes`;

  getContactTypes(): Observable<ContactType[]> {
    return this.http.get<ContactType[]>(this.baseUrl);
  }

  getContactTypeById(id: string): Observable<ContactType> {
    return this.http.get<ContactType>(`${this.baseUrl}/${id}`);
  }

  postContactType(reservation: ContactType) {
    return this.http.post(this.baseUrl, reservation);
  }

  putContactType(contactType: ContactType){
    return this.http.put(`${this.baseUrl}/${contactType.id}`,contactType);
  }

  delContactType(contactType: ContactType){
    return this.http.delete(`${this.baseUrl}/${contactType.id}`);
  }
}
