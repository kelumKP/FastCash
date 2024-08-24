import { Routes } from '@angular/router';
import { LoanApplicationComponent } from './features/customer/components/loan-application/loan-application.component';

export const routes: Routes = [
  { path: '', redirectTo: 'customer/loan-application', pathMatch: 'full' },  // Redirect root to the desired path
  { path: 'customer/loan-application', component: LoanApplicationComponent }
];