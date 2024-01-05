# TimeEntry

## appsettings.Development.json

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost,9301;Database=TimeEntry;User Id=sa;Password=DevDevDude119#;TrustServerCertificate=True;"
    }
}
``` 

## Migrations

create migration

```sh
dotnet ef migrations add MigrationName --startup-project RWT.Infrastructure --output-dir Migrations
```

update database
```sh
dotnet ef database update --startup-project RWT.Infrastructure
```

## sampel queries

all totos between two dates

```csharp
var todos = await _context.Todos
    .Where(t => t.Date >= startDate && t.Date <= endDate)
    .ToListAsync();
```

all totos between two dates for a client
  
```csharp
var todos = await _context.Todos
    .Where(t => t.Date >= startDate && t.Date <= endDate && t.ClientId == clientId)
    .ToListAsync();
```
