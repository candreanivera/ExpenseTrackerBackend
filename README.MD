# ExpenseTrackerBackend

A RESTful API built with ASP.NET Core for managing expenses and categories.

## Overview

This is the backend component of the Expense Tracker application. It provides endpoints to manage user transactions (expenses) and categories. It works in conjunction with the [ExpenseTrackerFrontEnd](https://github.com/candreanivera/ExpenseTrackerFrontEnd).

## Technologies Used

- ASP.NET Core Web API  
- Entity Framework Core  
- SQLite (can be replaced with SQL Server or another provider)  
- C#  
- Swagger (for API documentation)

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later installed  
- Visual Studio or Visual Studio Code  
- SQLite (optional, only needed if you want to manually inspect the database)

### Installation

1. ⭐ Clone the repository:
   ```bash
   git clone https://github.com/candreanivera/ExpenseTrackerBackend.git
    
    Navigate to the project directory:

    cd ExpenseTrackerBackend
    Restore dependencies:
    dotnet restore

2. ⭐ Running the Application
    Apply any pending migrations and update the database:
    dotnet ef database update

3. ⭐ Start the API:
    dotnet run
    The API will be available at:
    https://localhost:5001

4. ⭐ API Documentation
    Once the application is running, you can access Swagger UI for testing and exploring the endpoints:

    https://localhost:5001/swagger
    Available Endpoints
    The API provides endpoints for:

    Transactions

    GET /api/transactions
    POST /api/transactions
    PUT /api/transactions/{id}
    DELETE /api/transactions/{id}

5. ⭐ Notes
    Ensure CORS is enabled for frontend integration.

    You can switch the database provider from SQLite to SQL Server or others by updating the DbContext configuration.

    Deployment
    This backend can be deployed to:

    Azure App Service
    Docker container
    Any server supporting .NET Core

6. ⭐ License
    This project is open-source and free to use.