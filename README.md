# Loan Application System

## Overview

This project is a full-stack loan application system built using modern technologies. The system consists of a backend API, a frontend single-page application (SPA), and server-side rendering (SSR) for enhanced performance and SEO.

## Technologies Used

# Backend

### **C# .NET:**

- **ASP.NET Core:** Utilized for building a RESTful API to manage loan applications, including submitting and retrieving data.
- **Entity Framework Core:** An ORM framework that interacts with SQLite, simplifying database operations and ensuring efficient data management.
- **Dependency Injection:** Core to ASP.NET Core, enabling a modular and testable architecture by managing service lifetimes and dependencies.

### **Database:**

- **SQLite:** A lightweight, serverless, and self-contained database used to store loan application data and ensure quick access and minimal setup.

### **Middleware and Configuration:**

- **CORS (Cross-Origin Resource Sharing):** Configured to allow secure and specific communication between the frontend and backend, supporting various request origins.
- **Swagger:** Integrated for easy API documentation and interactive testing, enhancing the development and collaboration process.

# Frontend

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

# Project Structure

### **Backend Project Structure**

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
│   ├── Interfaces/
│   │   ├── ILoanApplicationManager.cs
│   │   └── ICustomerManager.cs
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
│   ├── Services/
│   │   └── LoanApplicationManagerTests.cs
│   └── other test files...

````

### **Frontend Project Structure**

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
### Swagger Preview for the API

<img width="2234" alt="Screenshot 2024-08-25 at 12 18 25 PM" src="https://github.com/user-attachments/assets/a7b638de-8a9c-4755-855f-b371818a7e0a">

### Successful request

<img width="2248" alt="Screenshot 2024-08-25 at 12 20 42 PM" src="https://github.com/user-attachments/assets/f6ce178b-f2ec-4c99-9141-c69184c43202">

<img width="2248" alt="Screenshot 2024-08-25 at 12 20 58 PM" src="https://github.com/user-attachments/assets/7cd1daa7-3448-47aa-8f77-225c43b1dbfb">

<img width="2248" alt="Screenshot 2024-08-25 at 12 21 05 PM" src="https://github.com/user-attachments/assets/a16421a9-e492-4b42-baba-6d4c352d54e9">

### Unsuccessful request

<img width="2248" alt="Screenshot 2024-08-25 at 12 21 22 PM" src="https://github.com/user-attachments/assets/9400989d-97e5-4ebd-818c-319e2bea3e0f">

<img width="2248" alt="Screenshot 2024-08-25 at 12 21 33 PM" src="https://github.com/user-attachments/assets/4b76ab11-e16b-4425-bda2-b9c0715e3708">

### Schema of the DB

<img width="1044" alt="Screenshot 2024-08-25 at 2 35 38 PM" src="https://github.com/user-attachments/assets/47d7755e-e519-4400-92f1-1d13b51e1b3d">

### Data stored in sqLite DB 

<img width="1044" alt="Screenshot 2024-08-25 at 2 35 23 PM" src="https://github.com/user-attachments/assets/16df6515-f001-40f7-a1f5-5e60ab86c149">

### Backend Testing Sample using xUnit

<img width="1044" alt="Screenshot 2024-08-25 at 2 35 23 PM" src="https://github.com/user-attachments/assets/ef912d7e-8f8c-4242-b790-171d3fb9b7ec">



