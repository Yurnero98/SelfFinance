# SelfFinance

Personal budgeting app built with ASP.NET Core (Web API) and Blazor Server.

## Technologies
- ASP.NET Core Web API
- Blazor Server
- Entity Framework Core
- MS SQL Server
- Azure App Service
- JWT Authentication
- Swagger (OpenAPI)

## Features
- User registration/login
- Income and expense tracking
- Category-based filtering
- Reports by day or period
- Secure REST API

## Getting Started

Prerequisites

.NET 8 SDK

MS SQL Server (local or remote)

Clone the repository

git clone https://github.com/Yurnero98/SelfFinance.git
cd SelfFinance

Configure the Database

In SelfFinance.WebApi/appsettings.json, update the connection string to match your SQL Server:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SelfFinanceDb;Integrated Security=true;TrustServerCertificate=true;"
}

Apply EF Core Migrations

cd SelfFinance.WebApi
 dotnet ef database update

Run the Backend API

dotnet run --project SelfFinance.WebApi

API will be available at a port like: https://localhost:7101 (check console output)

⚡ When you run the Web API project, Swagger UI will open automatically at `https://localhost:7101/swagger`,  
where you can explore and test all API endpoints interactively.

📡 API Endpoints (examples)

Method       Endpoint               Description

POST         /api/auth/login        Authenticate user

POST         /api/auth/register     Register new user

GET          /api/operations        Get all operations

POST         /api/operations        Add new operation

GET          /api/reports/daily     Daily financial report

GET          /api/reports/period    Period-based report

Full Swagger documentation available when you start WebApi project.

Configure Blazor UI

In SelfFinance.BlazorApp/appsettings.json, make sure the BaseUrl matches the backend:

"ApiSettings": {
  "BaseUrl": "https://localhost:7101"
}

⚠️ Ports may differ. Adjust to match the port used by SelfFinance.WebApi.

Then run:

dotnet run --project SelfFinance.BlazorApp

UI will be available at a port like: https://localhost:7224 (check console output)


## License
MIT
