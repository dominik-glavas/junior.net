# Restaurant API
  A simple ASP.NET Core Web API for managing restaurant orders

## Features
- Manage orders and articles within them
- Automatic calculation of total order price with currency conversion
- Swagger UI for exploring the API
- EF Core + SQL Server database with seed data

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/dominik-glavas/junior.net.git
   cd your-repo-name

2. Configure the database connection string in appsettings.Development.json to match your database:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=OrdersDb;Trusted_Connection=True;"
   }

3. Apply migrations and seed the database:
   ```bash
   dotnet ef database update

4. Run the app:
   ```bash
   dotnet run

5. Open https://localhost:7056/
