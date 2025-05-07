# Database Creation Instructions

## Option 1: Using psql command line

1. Open a terminal or command prompt
2. Run the following command to create the database:

```bash
psql -U postgres -f Scripts/create_database.sql
```

You'll be prompted for the postgres user password.

## Option 2: Using pgAdmin

1. Open pgAdmin
2. Connect to your PostgreSQL server
3. Right-click on "Databases" and select "Create" > "Database..."
4. Enter the following details:
   - Database: sims_web
   - Owner: postgres
5. Click "Save"

## Option 3: Using createdb command

Run the following command in your terminal:

```bash
createdb -U postgres sims_web
```

## Updating connection string

After creating the database, update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=sims_web;Username=postgres;Password=your_password"
}
```

Replace `your_password` with your actual PostgreSQL password.

## Database Migration

After creating the database, run the following commands to create the schema:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will create all the necessary tables based on your entity models.