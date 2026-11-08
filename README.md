# University Cafeteria MVC

ASP.NET Core MVC application demonstrating database-first and code-first Entity Framework Core workflows.

## Requirements

- .NET 10 SDK
- SQL Server or SQL Server Express

## Database-first setup

1. Run `Scripts/DatabaseFirst_Create.sql` in SQL Server Management Studio. It creates `CafeteriaDB` and the tables used by the database-first models.
2. Update `DefaultConnection` in `appsettings.json` if your SQL Server instance differs from `localhost`.

## Code-first setup

1. Update `CodeFirstConnection` in `appsettings.json` if needed.
2. From the project directory, run `dotnet ef database update --context CodeFirstDbContext` to create `CafeteriaCodeFirstDB` from the checked-in migration.

Then run `dotnet run`.
