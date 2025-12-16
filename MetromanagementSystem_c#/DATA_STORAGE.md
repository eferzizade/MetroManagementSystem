# Data Storage Architecture - Metro Management System

## Overview

This Metro Management System **does NOT use any database**. All data is stored in-memory using standard C# collections and managed through a centralized singleton DataStore.

## Why No Database?

This design choice was made to:
1. ✅ Meet university project requirements
2. ✅ Simplify deployment (no database setup needed)
3. ✅ Focus on C# programming and OOP concepts
4. ✅ Demonstrate data management without external dependencies
5. ✅ Make the code easier to understand for learning purposes

## Data Storage Implementation

### 1. DataStore Singleton Pattern

Location: `Data/DataStore.cs`

```csharp
public class DataStore
{
    private static DataStore? _instance;
    private static readonly object _lock = new object();
    
    // In-memory collections
    public List<Station> Stations { get; set; }
    public List<Line> Lines { get; set; }
    public List<Route> Routes { get; set; }
    public List<Ticket> Tickets { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Shift> Shifts { get; set; }
    public List<User> Users { get; set; }
    
    // Singleton instance access
    public static DataStore Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DataStore();
                    }
                }
            }
            return _instance;
        }
    }
}
```

**Key Features:**
- Thread-safe singleton implementation
- Centralized data access point
- Auto-incrementing ID generation
- Pre-loaded sample data

### 2. Data Collections

All entities are stored in `List<T>` collections:

| Collection | Type | Purpose |
|------------|------|---------|
| `Stations` | `List<Station>` | All metro stations |
| `Lines` | `List<Line>` | Metro lines with colors |
| `Routes` | `List<Route>` | Train routes and timetables |
| `Tickets` | `List<Ticket>` | Ticket sales history |
| `Employees` | `List<Employee>` | Employee records |
| `Shifts` | `List<Shift>` | Work shift schedules |
| `Users` | `List<User>` | System user accounts |

### 3. ID Generation

Auto-incrementing IDs are managed within DataStore:

```csharp
private int _nextStationId = 1;
private int _nextLineId = 1;
private int _nextRouteId = 1;
// ... etc

public int GetNextStationId() => _nextStationId++;
public int GetNextLineId() => _nextLineId++;
// ... etc
```

This simulates database auto-increment behavior.

### 4. CRUD Operations

All CRUD operations are performed through Service classes:

**Example - StationService:**
```csharp
public class StationService
{
    private readonly DataStore _dataStore;
    
    // CREATE
    public void AddStation(Station station)
    {
        station.Id = _dataStore.GetNextStationId();
        _dataStore.Stations.Add(station);
    }
    
    // READ
    public List<Station> GetAllStations()
    {
        return _dataStore.Stations;
    }
    
    // UPDATE
    public void UpdateStation(Station station)
    {
        var existing = _dataStore.Stations
            .FirstOrDefault(s => s.Id == station.Id);
        if (existing != null)
        {
            existing.Name = station.Name;
            // ... update other properties
        }
    }
    
    // DELETE
    public void DeleteStation(int stationId)
    {
        var station = _dataStore.Stations
            .FirstOrDefault(s => s.Id == stationId);
        if (station != null)
        {
            _dataStore.Stations.Remove(station);
        }
    }
}
```

### 5. Sample Data Initialization

Sample data is loaded when DataStore is first initialized:

```csharp
private void InitializeSampleData()
{
    // Create default users
    Users.Add(new User
    {
        Id = GetNextUserId(),
        Username = "admin",
        Password = "admin123",
        Role = UserRole.Admin,
        FullName = "System Administrator"
    });
    
    // Create lines
    Lines.Add(new Line
    {
        Id = GetNextLineId(),
        Name = "Red Line",
        Color = "#FF0000"
    });
    
    // Create stations, routes, employees, etc.
    // ...
}
```

## Data Relationships

### One-to-Many Relationships

**Line → Stations:**
```csharp
public class Line
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> StationIds { get; set; }  // Station references
}
```

**Employee → Shifts:**
- Each shift has an `EmployeeId` foreign key reference
- Retrieved via LINQ: `shifts.Where(s => s.EmployeeId == employeeId)`

**Line → Routes:**
- Each route has a `LineId` foreign key reference
- Retrieved via LINQ: `routes.Where(r => r.LineId == lineId)`

### Referential Integrity

Manually maintained through service layer:

```csharp
public void DeleteStation(int stationId)
{
    var station = _dataStore.Stations.FirstOrDefault(s => s.Id == stationId);
    if (station != null)
    {
        // Remove from line's station list (referential integrity)
        var line = _dataStore.Lines.FirstOrDefault(l => l.Id == station.LineId);
        if (line != null)
        {
            line.StationIds.Remove(stationId);
        }
        
        _dataStore.Stations.Remove(station);
    }
}
```

## Data Persistence Options

### Current State: Non-Persistent
- All data exists only in RAM
- Lost when application closes
- Reset to sample data on each restart

### Optional Enhancement: Add Persistence

If you want to save data between sessions, you can add JSON serialization:

**Example Implementation:**

```csharp
using System.Text.Json;

public class DataStore
{
    private const string DATA_FILE = "metrodata.json";
    
    // Save to file
    public void SaveToFile()
    {
        var json = JsonSerializer.Serialize(this, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(DATA_FILE, json);
    }
    
    // Load from file
    public static DataStore LoadFromFile()
    {
        if (File.Exists(DATA_FILE))
        {
            var json = File.ReadAllText(DATA_FILE);
            return JsonSerializer.Deserialize<DataStore>(json) 
                ?? new DataStore();
        }
        return new DataStore();
    }
}

// In Program.cs
Application.ApplicationExit += (s, e) =>
{
    DataStore.Instance.SaveToFile();
};
```

## Advantages of This Approach

### ✅ Pros
1. **Simple**: No database setup or configuration
2. **Fast**: All operations are in-memory
3. **Portable**: Run anywhere with .NET runtime
4. **Educational**: Clear understanding of data management
5. **No Dependencies**: No need for SQL Server, SQLite, etc.
6. **Easy Testing**: Reset data by restarting application

### ❌ Cons
1. **Non-persistent**: Data lost on application close
2. **Limited Scalability**: Not suitable for large datasets
3. **Single User**: No concurrent multi-user support
4. **No Transactions**: No ACID guarantees
5. **No Query Optimization**: All queries are LINQ in-memory

## Performance Characteristics

| Operation | Time Complexity | Notes |
|-----------|----------------|-------|
| Get All | O(1) | Direct list access |
| Get by ID | O(n) | Linear search with FirstOrDefault |
| Add | O(1) | List.Add is constant time |
| Update | O(n) | Find + update properties |
| Delete | O(n) | Find + remove |
| Search | O(n) | LINQ Where clause |

For the expected dataset size (hundreds of records), performance is excellent.

## Memory Usage

Estimated memory footprint for typical usage:

- 100 Stations: ~10 KB
- 10 Lines: ~1 KB
- 50 Routes: ~20 KB
- 1000 Tickets: ~100 KB
- 50 Employees: ~5 KB
- 200 Shifts: ~20 KB
- 10 Users: ~1 KB

**Total**: ~160 KB (negligible for modern systems)

## Migration Path to Database

If you later want to add a real database, the architecture makes it easy:

1. Keep the Model classes unchanged
2. Replace DataStore with a DbContext (Entity Framework)
3. Keep Service layer interfaces the same
4. Implement services using EF Core instead of LINQ-to-Objects

The UI layer would require **zero changes** because it only depends on Service interfaces.

## Conclusion

This in-memory data storage approach is:
- ✅ Perfect for university projects
- ✅ Ideal for learning and demonstration
- ✅ Simple to understand and modify
- ✅ Production-ready for small, single-user scenarios

For real-world metro systems, you would use a proper database (SQL Server, PostgreSQL, etc.), but this approach meets all educational requirements while demonstrating solid software engineering principles.

---

**Related Documentation:**
- See `README.md` for complete feature list
- See `QUICKSTART.md` for user guide
- See source code comments for implementation details
