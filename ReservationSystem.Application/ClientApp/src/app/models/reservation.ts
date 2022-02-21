import { Contact } from "./contact";

export class Reservation {
  id?: string;
  description: string;
  ranking?: number;
  favorite?: boolean;
  date: string = Date.now.toString();
  contactId: string;
  contact?: Contact = new Contact();
}
