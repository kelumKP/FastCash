import { TestBed, ComponentFixture } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { LoanApplicationComponent } from './loan-application.component';
import { By } from '@angular/platform-browser';

describe('LoanApplicationComponent', () => {
  let component: LoanApplicationComponent;
  let fixture: ComponentFixture<LoanApplicationComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, LoanApplicationComponent]  // Import the standalone component here
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoanApplicationComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
    fixture.detectChanges();
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize the form with empty values', () => {
    expect(component.loanApplication.customerId).toBe('');
    expect(component.loanApplication.amount).toBe(0);
    expect(component.loanApplication.status).toBe('');
  });

  it('should display success message on successful form submission', () => {
    // Arrange
    component.loanApplication = { customerId: '123', amount: 1000, status: 'Pending' };

    // Act
    component.onSubmit();

    // Simulate the backend response
    const req = httpMock.expectOne('http://localhost:5212/api/loan');
    req.flush({});

    // Assert
    expect(component.successMessage).toBe('Loan Request Submitted Successfully!');
    expect(component.errorMessage).toBe('');
  });

  it('should display error message on failed form submission', () => {
    // Arrange
    component.loanApplication = { customerId: '123', amount: 1000, status: 'Pending' };

    // Act
    component.onSubmit();

    // Simulate the backend error response
    const req = httpMock.expectOne('http://localhost:5212/api/loan');
    req.flush({}, { status: 500, statusText: 'Server Error' });

    // Assert
    expect(component.successMessage).toBe('');
    expect(component.errorMessage).toBe('There was an error submitting the loan request. Please try again.');
  });

  it('should clear the form after successful submission', () => {
    // Arrange
    component.loanApplication = { customerId: '123', amount: 1000, status: 'Pending' };

    // Act
    component.onSubmit();

    // Simulate the backend response
    const req = httpMock.expectOne('http://localhost:5212/api/loan');
    req.flush({});

    // Assert
    expect(component.loanApplication.customerId).toBe('');
    expect(component.loanApplication.amount).toBe(0);
    expect(component.loanApplication.status).toBe('');
  });
});