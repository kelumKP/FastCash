import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; // Import CommonModule
let LoanApplicationComponent = class LoanApplicationComponent {
    constructor(http) {
        this.http = http;
        this.loanApplication = { customerId: '', amount: 0, status: '' };
        this.successMessage = '';
        this.errorMessage = '';
    }
    onSubmit() {
        this.http.post('http://localhost:5212/api/loan', this.loanApplication)
            .subscribe({
            next: (response) => {
                this.successMessage = 'Loan Request Submitted Successfully!';
                this.errorMessage = '';
                this.clearForm();
            },
            error: (error) => {
                this.successMessage = '';
                this.errorMessage = 'There was an error submitting the loan request. Please try again.';
            }
        });
    }
    clearForm() {
        this.loanApplication = { customerId: '', amount: 0, status: '' };
    }
};
LoanApplicationComponent = __decorate([
    Component({
        selector: 'app-loan-application',
        standalone: true,
        imports: [FormsModule, CommonModule], // Include CommonModule here
        templateUrl: './loan-application.component.html',
        styleUrls: ['./loan-application.component.css']
    })
], LoanApplicationComponent);
export { LoanApplicationComponent };
//# sourceMappingURL=loan-application.component.js.map