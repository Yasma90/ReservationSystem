import { ContactType } from "./contact-type";

export class Contact {
  id?: string;
  name: string;
  phoneNumber: string;
  birthDate: string;
  contactTypeId: string;
  contactType?: ContactType;
}
