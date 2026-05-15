# MovieService API

MovieService API is a minimal viable product for managing a movie database.

## Goal

The goal of this project is to provide CRUD operations for movies stored in a PostgreSQL database using Entity Framework Core.

## Features

- Create movies
- Read movies
- Update movies
- Delete movies
- Store movie data in PostgreSQL
- Use Entity Framework Core for data access

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL

## Project Status

This project is currently in development as an MVP.

## Getting Started

### Prerequisites

- .NET 6 or later
- PostgreSQL installed and running

### Setup

1. Configure your database connection in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=movies;Username=postgres;Password=yourpassword"
   }
   ```

2. Apply database migrations:

   ```bash
   dotnet ef database update
   ```

3. Run the API:

   ```bash
   dotnet run
   ```

The API will start on `https://localhost:5001` (or the configured port).

### Testing

Once running, test the API endpoints using:

- **Swagger UI**: `https://localhost:5001/swagger` (if Swagger is configured)
- **Postman**: Import and test the endpoints manually
- **curl**: Use command-line requests

Example:

```bash
curl https://localhost:5001/api/movies
```
