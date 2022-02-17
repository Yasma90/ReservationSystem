import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-error-response',
  templateUrl: './error-response.component.html',
  styleUrls: ['./error-response.component.css']
})
export class ErrorResponseComponent implements OnInit {

  @Input()
  errors: string[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
