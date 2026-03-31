# Portfolio Backend API (.NET 8)

This is an ASP.NET Core Web API backend for portfolio/profile data.

## Stack
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL (Npgsql)
- Swagger/OpenAPI

## Run Locally
1. Go to the API project:
   - `cd backend/Portfolio.Api`
2. Set your DB connection string (recommended via environment variable):
   - PowerShell:
     - `$env:ConnectionStrings__DefaultConnection="Host=YOUR_DB_HOST;Port=5432;Database=postgres;Username=postgres;Password=YOUR_DB_PASSWORD;SSL Mode=Require;Trust Server Certificate=true"`
3. Run:
   - `dotnet run`
4. Open Swagger:
   - `http://localhost:5123/swagger`

## Configuration
- Connection string key: `ConnectionStrings:DefaultConnection`
- App reads from:
  - `appsettings.json`
  - `appsettings.Development.json`
  - environment variables (recommended for deployed environments)

## Deploy Notes (Render)
- Set environment variable:
  - `ConnectionStrings__DefaultConnection`
- Do not store real DB password in committed appsettings files.

## API + DB Docs
- See [API_AND_DATABASE.md](./API_AND_DATABASE.md) for endpoint list and table mapping.
