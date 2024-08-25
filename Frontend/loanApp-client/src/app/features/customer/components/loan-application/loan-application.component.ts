import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';  // Import CommonModule

@Component({
  selector: 'app-loan-application',
  standalone: true,
  imports: [FormsModule, CommonModule],  // Include CommonModule here
  templateUrl: './loan-application.component.html',
  styleUrls: ['./loan-application.component.css']
})
export class LoanApplicationComponent {
  loanApplication = { customerId: '', amount: 0, status: '' };
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private http: HttpClient) {} ///

  onSubmit() {
    this.http.post('http://localhost:5212/api/Loan/submit', this.loanApplication, { responseType: 'json' })
      .subscribe({
        next: (response) => {
          this.successMessage = 'Loan Request Submitted Successfully!';
          this.errorMessage = '';
          this.clearForm();
        },
        error: (error) => {
          this.successMessage = '';
          if (error.status === 400) {
            this.errorMessage = 'There was an error submitting the loan request. Please check your input and try again.';
          } else if (error.status === 500) {
            this.errorMessage = 'There was an error submitting the loan request. Please try again.';
          } else {
            this.errorMessage = 'There was an error submitting the loan request. Please try again.';
          }
        }
      });
  }

  clearForm() {
    this.loanApplication = { customerId: '', amount: 0, status: '' };
  }
}