import { Contact } from "./contact";

export class Reservation {
  id:string;
  description: string;
  ranking: number;
  favorite: boolean;
  contactId: string;
  contact: Contact = new Contact();
  date:string = Date.now.toString();
}
