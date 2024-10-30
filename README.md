# Candidate Management Application

## Overview

This application is designed to manage candidate information, providing functionalities to add and update candidate data. It serves as an API for handling candidate profiles, leveraging a well-structured architecture to ensure maintainability and scalability.

## Architecture

### Onion Architecture

The application follows **Onion Architecture**, which emphasizes the separation of concerns and promotes a clear distinction between different parts of the application. 

#### Key Layers:

1. **Core Layer (Domain Layer)**:
   - Contains core business logic and domain entities (e.g., `Candidate` class) as well as repository interfaces (e.g., `ICandidateRepository`). This layer is independent of any external dependencies, focusing solely on the application's domain.

2. **Application Layer**:
   - Comprises application services (e.g., `ICandidateService` and `CandidateService`) that implement business logic and orchestrate interactions between the domain and the data access layer.

3. **Infrastructure Layer**:
   - Includes data access implementations (e.g., `CandidateRepository`) that handle data persistence using Entity Framework Core. This layer implements the interfaces defined in the domain layer.

4. **Presentation Layer**:
   - Consists of controllers (e.g., `CandidatesController`) that handle incoming HTTP requests and return responses while interacting with application services.

### Advantages of Onion Architecture

- **Separation of Concerns**: Each layer has a distinct responsibility, making the codebase easier to manage and understand.
- **Testability**: The architecture allows for easy unit testing of the core business logic without requiring external dependencies.
- **Flexibility**: Changes in the outer layers (like switching from one database technology to another) do not affect the core business logic.
- **Maintainability**: The clear separation makes the application easier to maintain and extend over time.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (version compatible with the project)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or a compatible database server
- Visual Studio or any .NET-compatible IDE

## Configuration

### Updating `appsettings.json`

1. Open the `appsettings.json` file in the **main project**.

2. Locate the `ConnectionStrings` section. It should look something like this:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;"
   }

3. Goto Package Manager Console and set the default project as CandidateManagement.Infrastructure.
4. Run script "Add-Migration "Migration Name".
5. Run Script "Update-Database".

## Improvements that can be made

### 1. **CORS Policy**
   - **Issue**: The application currently lacks a CORS policy, which may lead to access issues from different origins.
   - **Improvement**: Implement a CORS policy to allow specific origins, methods, and headers.

### 2. **Error Handling Middleware**
   - **Issue**: There is no centralized error handling mechanism.
   - **Improvement**: Create an `ExceptionHandlingMiddleware` to catch exceptions globally and provide standardized error responses.

### 3. **Logging Enhancements**
   - **Issue**: Basic logging is available but lacks structure and flexibility.
   - **Improvement**: Integrate a structured logging library like Serilog for better log management and analysis.

### 4. **Environment-Specific Configuration**
   - **Issue**: Configuration settings are not optimized for different environments.
   - **Improvement**: Use `appsettings.Development.json`, `appsettings.Production.json`, etc., for environment-specific settings.

### 5. **Validation Improvements**
   - **Issue**: Validation logic is minimal.
   - **Improvement**: Implement more detailed validation attributes in the DTOs and consider using FluentValidation for complex scenarios.

### 6. **Security Enhancements**
   - **Issue**: Application security practices are not defined.
   - **Improvement**: Implement security measures such as input validation, secure connection strings, and protection against common vulnerabilities (e.g., SQL injection, XSS).

### 11. **Generic Repository Pattern**
   - **Issue**: The current repository implementation is specific to the `Candidate` entity, which may lead to code duplication in future repository classes.
   - **Improvement**: Implement a Generic Repository Pattern to allow for reusable data access methods across different entities, reducing code duplication and improving maintainability. This could involve creating a base repository interface and a concrete implementation.

---

## Assumptions

1. **Development Environment**: It is assumed that the development is taking place in a local environment with access to necessary tools (e.g., SQL Server, .NET SDK).

2. **Database Design**: The database schema is assumed to be optimized, and all necessary indexes are applied for performance.

3. **Future Requirements**: It is assumed that future requirements may include additional features such as candidate skill sets, application tracking, or user role management.

---

## Total Time Taken

The total time taken to develop this application is below:
- **Domain class Library  Implementation**: 1 hours
- **Infrastructure class Library Implementation**: 2 hours
- **Application Class Library Integration**: 2 hours
- **Main Application Implementation**: 1 hours
- **Unit Test**: 1 hours
- **Documentation**: 1 hours
  
