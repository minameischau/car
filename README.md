# 🚗 CaraCara - Automotive Management System

CaraCara is a modern automotive dealership management system built on **.NET 8** using **Clean Architecture** and **CQRS** patterns.

## 🏗 Project Architecture

The system is organized into the following layers:

- **CaraCara.API**: Presentation layer, providing RESTful API endpoints.
- **CaraCara.Application**: Logic layer containing Business Logic, using MediatR for Command and Query routing.
- **CaraCara.Domain**: Core layer containing Entities, Interfaces, and fundamental business rules.
- **CaraCara.Infrastructure**: Implementation layer for external services such as Database (EF Core), Logging (Serilog), and Identity.
- **CaraCara.SharedSettings**: Contains shared configuration files for the entire solution.

## 🛠 Tech Stack

- **Framework**: .NET 8
- **ORM**: Entity Framework Core (SQL Server)
- **Pattern**: CQRS with MediatR
- **Mapping**: AutoMapper
- **Validation**: FluentValidation
- **Authentication**: ASP.NET Core Identity
- **Logging**: Serilog

## 🚀 Getting Started

### 1. Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (LocalDB or Full version)

### 2. Configuration
The project uses **User Secrets** to secure local configuration. To start, create a file `CaraCara.API/appsettings.Secrets.json` (already ignored by git) and load it into the secret store:

```powershell
# Inside CaraCara.API directory
Get-Content appsettings.Secrets.json | dotnet user-secrets set
```

### 3. Database Migration
Run the following commands from the root directory to initialize the Database:

```powershell
dotnet ef migrations add InitialCreate --project CaraCara.Infrastructure --startup-project CaraCara.API
dotnet ef database update --project CaraCara.Infrastructure --startup-project CaraCara.API
```

### 4. Running the Project
Use the utility script for quick build and run:
```powershell
./run.ps1
```
Or use the standard dotnet command:
```powershell
dotnet run --project CaraCara.API
```

## 📝 API Endpoints
- **Swagger UI**: `https://localhost:<port>/swagger`
- **Weather Forecast**: `GET /weatherforecast`
- **Vehicles List (CQRS Demo)**: `GET /api/vehicles`

## 🛡 Security Note
Sensitive files like `appsettings.Secrets.json`, `*.local.json`, and IDE folders (`.vs`, `.idea`) are configured in `.gitignore` to ensure source code security.
