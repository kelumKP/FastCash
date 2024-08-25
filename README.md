# Loan Application System

This repository contains a Loan Application System, which is developed using a modern technology stack including .NET for the backend and Angular for the frontend. The system provides a complete solution for submitting and managing loan applications.

## Backend Technologies

- **.NET 7.0**: The core framework used for building the backend API.
- **Entity Framework Core**: An ORM (Object-Relational Mapper) for database operations with SQLite.
- **SQLite**: A lightweight, file-based relational database used for storing data (`loanapp.db`).
- **ASP.NET Core**: A framework for building web APIs.
- **Swagger**: Integrated for API documentation and testing.

## Backend Libraries

- **Microsoft.EntityFrameworkCore**: Core library for Entity Framework, enabling database operations.
- **Microsoft.EntityFrameworkCore.Sqlite**: SQLite-specific provider for Entity Framework Core.
- **Microsoft.AspNetCore.Mvc**: Provides the structure for building HTTP APIs.
- **System.IO**: Used for file and directory operations, such as setting the database path.

## Backend Testing Frameworks

- **xUnit**: A unit testing framework used in the `LoanApp.Tests` project to test the application logic.
- **Moq**: A popular mocking library that can be used in conjunction with xUnit for creating mock objects in tests.

## Frontend Technologies

- **Angular**: A TypeScript-based frontend framework used for building the client-side application.
- **Angular SSR (Server-Side Rendering)**: Used for rendering the application on the server for improved performance and SEO.
- **TypeScript**: A superset of JavaScript, adding static types to the language.
- **RxJS**: A library for reactive programming with asynchronous data streams.

## Frontend Libraries

- **Angular Forms**: For building and managing forms.
- **Angular Router**: For navigating between different views in the Angular application.
- **Zone.js**: A library for managing async operations in Angular.

## Frontend Testing Frameworks

- **Karma**: A test runner that works with Jasmine to run tests in various browsers.
- **Jasmine**: A behavior-driven development framework for testing JavaScript code.

## Project Structure

### Backend Project Structure

```plaintext
Backend/
├── LoanApp.API/
│   ├── Controllers/
│   │   └── LoanController.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── launchSettings.json
│
├── LoanApp.Application/
│   ├── Dtos/
│   │   ├── CustomerDto.cs
│   │   └── LoanApplicationDto.cs
│   ├── Services/
│       └── LoanApplicationManager.cs
│
├── LoanApp.Core/
│   ├── Events/
│   │   ├── LoanApplicationSubmittedEvent.cs
│   │   ├── LoanApprovedEvent.cs
│   │   └── LoanRejectedEvent.cs
│   ├── Interfaces/
│   │   ├── ICustomerService.cs
│   │   ├── IEmailService.cs
│   │   └── IEventBus.cs
│   ├── Models/
│   │   ├── Customer.cs
│   │   ├── LoanApplication.cs
│   │   └── LoanStatusHistory.cs
│   └── Services/
│       └── EmailService.cs
│
├── LoanApp.Infrastructure/
│   ├── Data/
│   │   ├── Configurations/
│   │   ├── Repositories/
│   │   │   ├── CustomerRepository.cs
│   │   │   └── LoanApplicationRepository.cs
│   │   ├── loanapp.db
│   │   └── LoansUnlimitedContext.cs
│   └── Services/
│       ├── CreditCheckServices.cs
│       ├── EmailClientServices.cs
│       └── SftpClientServices.cs
│
├── LoanApp.Tests/
│   ├── LoanApplicationServiceTests.cs
│   └── other test files...
````

### Frontend Project Structure

```plaintext
Frontend/
loans-unlimited-client/
│
├── src/
│   ├── app/
│   │   ├── core/
│   │   │   ├── services/
│   │   │   │   ├── auth.service.ts
│   │   │   │   ├── loan.service.ts
│   │   │   │   ├── notification.service.ts
│   │   │   ├── interceptors/
│   │   │   │   ├── auth.interceptor.ts
│   │   │   ├── guards/
│   │   │   │   ├── auth.guard.ts
│   │   │   ├── models/
│   │   │   │   ├── customer.model.ts
│   │   │   │   ├── loan-application.model.ts
│   │   │   └── utils/
│   │   │       ├── date-util.ts
│   │   │       ├── validation-util.ts
│   │   │
│   │   ├── shared/
│   │   │   ├── components/
│   │   │   │   ├── header/
│   │   │   │   │   ├── header.component.ts
│   │   │   │   │   ├── header.component.html
│   │   │   │   │   ├── header.component.css
│   │   │   ├── directives/
│   │   │   │   ├── custom-validator.directive.ts
│   │   │   ├── pipes/
│   │   │       ├── date-format.pipe.ts
│   │   │       ├── currency-format.pipe.ts
│   │   │
│   │   ├── features/
│   │   │   ├── customer/
│   │   │   │   ├── components/
│   │   │   │   │   ├── customer-dashboard/
│   │   │   │   │   │   ├── customer-dashboard.component.ts
│   │   │   │   │   │   ├── customer-dashboard.component.html
│   │   │   │   │   │   ├── customer-dashboard.component.css
│   │   │   │   │   ├── loan-application-form/
│   │   │   │   │   │   ├── loan-application-form.component.ts
│   │   │   │   │   │   ├── loan-application-form.component.html
│   │   │   │   │   │   ├── loan-application-form.component.css
│   │   │   │   ├── services/
│   │   │   │   │   ├── customer.service.ts
│   │   │   │   ├── customer-routing.module.ts
│   │   │   │   ├── customer.module.ts
│   │   │
│   │   │   ├── agent/
│   │   │   │   ├── components/
│   │   │   │   │   ├── agent-dashboard/
│   │   │   │   │   │   ├── agent-dashboard.component.ts
│   │   │   │   │   │   ├── agent-dashboard.component.html
│   │   │   │   │   │   ├── agent-dashboard.component.css
│   │   │   │   │   ├── loan-management/
│   │   │   │   │   │   ├── loan-management.component.ts
│   │   │   │   │   │   ├── loan-management.component.html
│   │   │   │   │   │   ├── loan-management.component.css
│   │   │   │   ├── services/
│   │   │   │   │   ├── agent.service.ts
│   │   │   │   ├── agent-routing.module.ts
│   │   │   │   ├── agent.module.ts
│   │   │
│   │   ├── app-routing.module.ts
│   │   ├── app.component.ts
│   │   ├── app.component.html
│   │   ├── app.component.css
│   │   └── app.module.ts
│   │
│   ├── assets/
│   ├── environments/
│   │   ├── environment.ts
│   │   └── environment.prod.ts
│   ├── index.html
│   ├── main.ts
│   ├── polyfills.ts
│   ├── styles.css
│   └── test.ts
│
├── angular.json
├── package.json
├── tsconfig.json
└── tslint.json
````

<img width="2234" alt="Screenshot 2024-08-25 at 12 18 25 PM" src="https://github.com/user-attachments/assets/a7b638de-8a9c-4755-855f-b371818a7e0a">
<img width="2248" alt="Screenshot 2024-08-25 at 12 20 42 PM" src="https://github.com/user-attachments/assets/f6ce178b-f2ec-4c99-9141-c69184c43202">
<img width="2248" alt="Screenshot 2024-08-25 at 12 20 58 PM" src="https://github.com/user-attachments/assets/7cd1daa7-3448-47aa-8f77-225c43b1dbfb">
<img width="2248" alt="Screenshot 2024-08-25 at 12 21 05 PM" src="https://github.com/user-attachments/assets/a16421a9-e492-4b42-baba-6d4c352d54e9">
<img width="2248" alt="Screenshot 2024-08-25 at 12 21 22 PM" src="https://github.com/user-attachments/assets/9400989d-97e5-4ebd-818c-319e2bea3e0f">
<img width="2248" alt="Screenshot 2024-08-25 at 12 21 33 PM" src="https://github.com/user-attachments/assets/4b76ab11-e16b-4425-bda2-b9c0715e3708">
<img width="1044" alt="Screenshot 2024-08-25 at 2 35 38 PM" src="https://github.com/user-attachments/assets/47d7755e-e519-4400-92f1-1d13b51e1b3d">
<img width="1044" alt="Screenshot 2024-08-25 at 2 35 23 PM" src="https://github.com/user-attachments/assets/16df6515-f001-40f7-a1f5-5e60ab86c149">


