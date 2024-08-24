import { __decorate } from "tslib";
// app.component.ts
import { Component } from '@angular/core';
import { LoanApplicationComponent } from './features/customer/loan-application/loan-application.component';
let AppComponent = class AppComponent {
    constructor() {
        this.title = 'loanApp-client';
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app-root',
        standalone: true,
        imports: [LoanApplicationComponent], // Import the LoanApplicationComponent
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.css']
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map