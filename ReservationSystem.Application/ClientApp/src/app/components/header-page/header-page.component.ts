import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-header-page',
  templateUrl: './header-page.component.html',
  styleUrls: ['./header-page.component.css']
})
export class HeaderPageComponent implements OnInit {

  @Input()
    routeUrl: string = '/';
  @Input()
    title: string = 'Reservations List';
  @Input()
    action: string = 'CREATE RESERVATION';
  readonly description : string = `Lorem ipsum dolor sit amet, consectetur adipiscing elit,
  sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.`

  constructor() { }

  ngOnInit(): void {
  }

}
