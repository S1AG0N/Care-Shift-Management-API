# Care Shift Management API
## Overview
A RESTful API built with ASP.NET Core 8 that manages care workers, shift scheduling,
and incident reporting. Designed to reflect real-world care sector workflows from my
experience as a senior care worker.
## Live Demo
Base URL: https://careshiftapi.azurewebsites.net
Swagger UI: https://careshiftapi.azurewebsites.net/swagger
## Tech Stack
- ASP.NET Core 8 Web API
- Entity Framework Core 8 (Code First)
- SQL Server / Azure SQL
- JWT Authentication
- xUnit (unit tests)
## Key Features
- Role-based access control (Worker / Supervisor / Admin)
- Shift conflict detection — prevents double-booking
- Incident log with severity filtering and summary reporting
- Worker availability management
## Getting Started (Local)
1. Clone the repo
2. Update appsettings.json with your SQL Server connection string
3. Run: dotnet ef database update
4. Run: dotnet run
5. Navigate to https://localhost:xxxx/swagger
