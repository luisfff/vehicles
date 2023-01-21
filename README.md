# README #

Vehicles API

This API allows you to create, read, update, and delete vehicles using the UnitOfWork pattern and Entity Framework Core (EF) migrations in .NET 7.

## Getting Started
Clone the repository to your local machine.

Build the solution to restore the NuGet packages.

Run the command "dotnet ef database update" terminal to create the database and apply the migrations.

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
