import { ContactType } from "./contact-type";

export class Contact {
  id?: string;
  name: string;
  phone: string;
  birthDate: string;
  contactTypeId: string;
  ContactType: ContactType = new ContactType();
}
