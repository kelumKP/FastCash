# Loan Application System

## Overview

This project is a full-stack loan application system built using modern technologies. The system consists of a backend API, a frontend single-page application (SPA), and server-side rendering (SSR) for enhanced performance and SEO.

## Technologies Used

### Backend

- **C# .NET**:
  - **ASP.NET Core**: Utilized for building a RESTful API to handle loan application requests and manage data.
  - **Entity Framework Core**: Used for database operations with SQLite, allowing for seamless interaction between the application and the database.
  - **Dependency Injection**: Managed by ASP.NET Core to promote modularity and testability.

- **Database**:
  - **SQLite**: A lightweight relational database used to store loan application data.

- **Middleware and Configuration**:
  - **CORS (Cross-Origin Resource Sharing)**: Configured to allow requests from specific origins, ensuring secure communication between frontend and backend.
  - **Swagger**: Integrated for API documentation and testing, making it easier to understand and interact with the API.

### Frontend

- **Angular**:
  - **Angular Core**: Provides the foundation for building a responsive and dynamic single-page application (SPA).
  - **Angular Forms**: Facilitates form validation and management of user input.
  - **Angular Router**: Manages routing and navigation within the application.
  - **Angular SSR (Server-Side Rendering)**: Configured with Angular Universal to improve performance and SEO by pre-rendering pages on the server.

- **TypeScript**: A statically typed superset of JavaScript that enhances code quality and developer productivity.

- **RxJS**: Employed for managing asynchronous data streams and events, crucial for handling user interactions and real-time updates.

- **Express.js**: Used in conjunction with Angular Universal to handle server-side rendering (SSR) and serve the Angular application.

- **Zone.js**: Manages asynchronous operations in Angular, ensuring that the application’s change detection works seamlessly.

### Testing

- **Karma**: A test runner that allows you to run tests in a browser environment, ensuring that the application works correctly across different platforms.
  
- **Jasmine**: A behavior-driven development (BDD) framework used for writing unit and integration tests for the Angular application.

- **Karma Chrome Launcher**: A plugin that runs tests in the Chrome browser, facilitating a real-world testing environment.

- **Karma Coverage**: Generates code coverage reports to help identify untested parts of the codebase.

### Build Tools

- **Angular CLI**: A powerful command-line interface tool that simplifies the creation, management, and testing of Angular applications.

- **Webpack**: A module bundler used by Angular CLI to efficiently bundle JavaScript, CSS, and other assets for production.

### Miscellaneous

- **Tslib**: A runtime library for TypeScript, providing essential helper functions to support TypeScript features.

- **Node.js**: The runtime environment used to execute server-side JavaScript, particularly for the SSR with Express.

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


