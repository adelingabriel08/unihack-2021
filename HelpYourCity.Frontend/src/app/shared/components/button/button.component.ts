import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent {
  @Input() selected = false;
  @Input() label: string;
  @Input() hoverEnabled = false;
  @Output() readonly action = new EventEmitter<any>();
}
