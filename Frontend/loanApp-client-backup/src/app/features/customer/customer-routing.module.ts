import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoanApplicationComponent } from './components/loan-application/loan-application.component';

const routes: Routes = [
  { path: 'loan-application', component: LoanApplicationComponent }  // No need to include 'customer' here
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule {}
