
# HumanResourcesService

HumanResourcesService is a .NET 8 Web API for managing human resources data, including employees and departments. It uses Entity Framework Core with a SQLite database for persistence.

## Features
- CRUD operations for Employees and Departments
- RESTful API endpoints
- Authentication stub for future integration
- Layered architecture (Controllers, Services, Repositories, DTOs, Models)

## Project Structure
```
HumanResourcesService/
├── Authentication/         # AuthStub for authentication logic
├── Controllers/            # API controllers (Employee, Department)
├── Data/                   # DbContext for EF Core
├── DTOs/                   # Data Transfer Objects
├── Models/                 # Entity models
├── Repositories/           # Data access layer
├── Services/               # Business logic layer
├── appsettings.json        # Configuration files
├── HumanResources.db       # SQLite database
├── Program.cs              # Main entry point
├── ...                     # Other files
```

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Setup
1. Clone the repository:
	```bash
	git clone <repo-url>
	cd HumanResourcesService
	```
2. Restore dependencies:
	```bash
	dotnet restore
	```
3. Build the project:
	```bash
	dotnet build
	```
4. Run the API:
	```bash
	dotnet run
	```

### API Endpoints
- `GET /api/employees` - List all employees
- `GET /api/employees/{id}` - Get employee by ID
- `POST /api/employees` - Create new employee
- `PUT /api/employees/{id}` - Update employee
- `DELETE /api/employees/{id}` - Delete employee
- Similar endpoints for departments

## Configuration
- Update connection strings and settings in `appsettings.json` and `appsettings.Development.json` as needed.

## Database
- Uses SQLite (`HumanResources.db`).
- Entity Framework Core handles migrations and data access.

## Authentication
- Basic authentication stub included in `Authentication/AuthStub.cs`.
- Extend for real authentication as needed.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
This project is licensed under the MIT License.
