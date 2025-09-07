# WARP.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.

## Project Overview

This is a .NET 9.0 e-commerce solution implementing a REST API with a Blazor Server frontend. The project is a Swedish language assignment ("Labb 2") that follows Clean Architecture principles with separation of concerns through multiple projects.

## Architecture

### Project Structure
- **API** - Minimal API endpoints using endpoint groups
- **Application** - Business logic services implementing interfaces
- **DataAccess** - Repository pattern with Unit of Work, Entity Framework Core
- **Domain** - Entity models and core business objects  
- **Client** - Blazor Server frontend with Radzen components and ASP.NET Identity

### Key Architectural Patterns
- **Repository Pattern**: All data access through repositories implementing `IRepository<T>`
- **Unit of Work Pattern**: Transaction management via `IUnitOfWork`
- **Dependency Injection**: Services registered in `ServiceExtensions.cs`
- **Clean Architecture**: Clear separation between domain, application, and infrastructure layers
- **Minimal API**: Endpoints defined as extension methods in separate files

## Common Commands

### Build and Run
```bash
# Build entire solution
dotnet build

# Run API project (default port 5207)
dotnet run --project API

# Run Client project (Blazor frontend)
dotnet run --project Client

# Run both projects simultaneously (recommended for development)
# Terminal 1:
dotnet run --project API
# Terminal 2:
dotnet run --project Client
```

### Database Operations
```bash
# Create new migration
dotnet ef migrations add MigrationName --project DataAccess --startup-project API

# Update database
dotnet ef database update --project DataAccess --startup-project API

# Drop database (development only)
dotnet ef database drop --project DataAccess --startup-project API
```

### Testing Individual Components
```bash
# Test specific endpoints with curl
curl -X GET "http://localhost:5207/api/products"
curl -X GET "http://localhost:5207/api/customers"
curl -X GET "http://localhost:5207/api/categories"
```

## Database Configuration

### Connection Strings
- **AndersBrodDb**: Main business database (SQL Server)  
- **DefaultConnection**: Identity/authentication database (LocalDB)

### Key Entities
- Products (with Categories, Status for inventory)
- Customers (with full address information)
- Orders and OrderDetails (many-to-many relationship)
- Categories

## Development Notes

### API Endpoints
The API follows RESTful conventions with endpoints grouped by entity:
- `/api/products` - CRUD operations, status updates, category assignment
- `/api/customers` - CRUD operations, search by email/city
- `/api/orders` - CRUD operations, shipping status updates  
- `/api/categories` - Basic CRUD operations
- `/api/orderdetails` - Order line item management

### Service Layer
Each entity has a corresponding service implementing business logic:
- Services depend on `IUnitOfWork` for data access
- Services are registered as scoped dependencies
- Validation and business rules implemented in service layer

### Frontend Integration
- Client communicates with API via HTTP client configured for `http://localhost:5207/`
- Uses Radzen Blazor components for UI
- Implements ASP.NET Identity for authentication
- Services in Client project mirror API structure for data operations

### Key Configuration Files
- `API/appsettings.json` - Database connection strings
- `DataAccess/ServiceExtensions/ServiceExtensions.cs` - DI configuration
- `planering.md` - Detailed API endpoint specifications (Swedish)

## Repository Pattern Details

All repositories implement `IRepository<T>` with standard CRUD operations. Specialized repositories extend this interface for entity-specific operations (e.g., `GetProductByName`, `GetCustomerByEmail`).

The Unit of Work coordinates all repositories and manages database transactions through a single `Commit()` call.
