# Vehicles API #
This API allows you to create, read, update, and delete vehicles using the UnitOfWork pattern and Entity Framework Core (EF) migrations.

## Getting Started
Clone the repository: git clone https://github.com/luisfff/vehicles

Restore dependencies: `dotnet restore`.

Create database and apply migrations: in the Vehicles.Api folder run `dotnet ef database update`.

Run the project: `dotnet run`.

Note: Production version of deployment can be acessed at: https://vehicles-action.azurewebsites.net/swagger/index.html

Access the API at http://localhost:5131

## Endpoints
GET /api/models: Retrieve a list of all vehicle models.

GET /api/vehicles: Retrieve a list of all vehicles.

GET /api/vehicles/{id}: Retrieve a specific vehicle by ID.

POST /api/vehicles: Create a new vehicle.

PUT /api/vehicles/{id}: Update an existing vehicle.

DELETE /api/vehicles/{id}: Delete a specific vehicle by ID.

## UnitOfWork and Repository Pattern
The API uses the UnitOfWork and Repository pattern to abstract the data access logic and provide a cleaner, more maintainable codebase.

## Migrations
Entity framework migrations are used to manage the database schema.

To apply migrations, use the command "dotnet ef database update" in the terminal. To create a new migration, use the command "dotnet ef migrations add <MigrationName>".

## Connection String
The API uses a local SQL Server database. The connection string is located in the appsettings.json file. If you need to use a different database, update the connection string accordingly.
