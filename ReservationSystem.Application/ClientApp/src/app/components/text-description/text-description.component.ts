import { Component, OnInit } from '@angular/core';
import { HtmlEditorService, ImageService, LinkService, QuickToolbarService, ToolbarService } from '@syncfusion/ej2-angular-richtexteditor';

@Component({
  selector: 'app-text-description',
  templateUrl: './text-description.component.html',
  styleUrls: ['./text-description.component.css'],
  providers: [ToolbarService, LinkService, ImageService, HtmlEditorService,     QuickToolbarService]
})
export class TextDescriptionComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
