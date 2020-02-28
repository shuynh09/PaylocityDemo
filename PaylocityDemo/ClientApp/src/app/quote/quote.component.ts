import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-quote-component',
  templateUrl: './quote.component.html'
})

export class QuoteComponent {
  @Input() quote: any;
}
