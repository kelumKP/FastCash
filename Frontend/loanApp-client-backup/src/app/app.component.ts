import { Component } from '@angular/core';
import { LoanApplicationComponent } from './features/customer/components/loan-application/loan-application.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [LoanApplicationComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'loanApp-client';
}