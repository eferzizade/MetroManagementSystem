using metrosistemi.Models;

namespace metrosistemi.Data
{
    /// <summary>
    /// Centralized in-memory data store for all entities
    /// This simulates a database using collections
    /// </summary>
    public class DataStore
    {
        private static DataStore? _instance;
        private static readonly object _lock = new object();

        // Collections for all entities
        public List<Station> Stations { get; set; }
        public List<Line> Lines { get; set; }
        public List<Route> Routes { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Shift> Shifts { get; set; }
        public List<User> Users { get; set; }

        // Auto-increment IDs
        private int _nextStationId = 1;
        private int _nextLineId = 1;
        private int _nextRouteId = 1;
        private int _nextTicketId = 1;
        private int _nextEmployeeId = 1;
        private int _nextShiftId = 1;
        private int _nextUserId = 1;

        /// <summary>
        /// Singleton instance
        /// </summary>
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

        private DataStore()
        {
            Stations = new List<Station>();
            Lines = new List<Line>();
            Routes = new List<Route>();
            Tickets = new List<Ticket>();
            Employees = new List<Employee>();
            Shifts = new List<Shift>();
            Users = new List<User>();

            InitializeSampleData();
        }

        /// <summary>
        /// Initialize sample data for testing
        /// </summary>
        private void InitializeSampleData()
        {
            // Create default admin user
            Users.Add(new User
            {
                Id = GetNextUserId(),
                Username = "admin",
                Password = "admin123",
                Role = UserRole.Admin,
                FullName = "System Administrator",
                IsActive = true
            });

            Users.Add(new User
            {
                Id = GetNextUserId(),
                Username = "operator",
                Password = "operator123",
                Role = UserRole.Operator,
                FullName = "Metro Operator",
                IsActive = true
            });

            // Create Lines
            var line1 = new Line
            {
                Id = GetNextLineId(),
                Name = "Red Line",
                Color = "#FF0000"
            };
            Lines.Add(line1);

            var line2 = new Line
            {
                Id = GetNextLineId(),
                Name = "Blue Line",
                Color = "#0000FF"
            };
            Lines.Add(line2);

            var line3 = new Line
            {
                Id = GetNextLineId(),
                Name = "Green Line",
                Color = "#00FF00"
            };
            Lines.Add(line3);

            // Create Stations for Red Line
            var station1 = new Station
            {
                Id = GetNextStationId(),
                Name = "Central Station",
                Address = "123 Main St",
                Latitude = 41.0082,
                Longitude = 28.9784,
                LineId = line1.Id
            };
            Stations.Add(station1);
            line1.StationIds.Add(station1.Id);

            var station2 = new Station
            {
                Id = GetNextStationId(),
                Name = "North Terminal",
                Address = "456 North Ave",
                Latitude = 41.0182,
                Longitude = 28.9884,
                LineId = line1.Id
            };
            Stations.Add(station2);
            line1.StationIds.Add(station2.Id);

            var station3 = new Station
            {
                Id = GetNextStationId(),
                Name = "South Terminal",
                Address = "789 South Blvd",
                Latitude = 40.9982,
                Longitude = 28.9684,
                LineId = line1.Id
            };
            Stations.Add(station3);
            line1.StationIds.Add(station3.Id);

            // Create Stations for Blue Line
            var station4 = new Station
            {
                Id = GetNextStationId(),
                Name = "East Station",
                Address = "321 East St",
                Latitude = 41.0082,
                Longitude = 29.0084,
                LineId = line2.Id
            };
            Stations.Add(station4);
            line2.StationIds.Add(station4.Id);

            var station5 = new Station
            {
                Id = GetNextStationId(),
                Name = "West Station",
                Address = "654 West Ave",
                Latitude = 41.0082,
                Longitude = 28.9484,
                LineId = line2.Id
            };
            Stations.Add(station5);
            line2.StationIds.Add(station5.Id);

            // Create Routes
            var route1 = new Route
            {
                Id = GetNextRouteId(),
                LineId = line1.Id,
                Name = "Red Line - Morning",
                FirstDeparture = new TimeSpan(6, 0, 0),
                LastDeparture = new TimeSpan(23, 0, 0),
                FrequencyMinutes = 10
            };
            route1.GenerateDepartureTimes();
            Routes.Add(route1);

            var route2 = new Route
            {
                Id = GetNextRouteId(),
                LineId = line2.Id,
                Name = "Blue Line - All Day",
                FirstDeparture = new TimeSpan(5, 30, 0),
                LastDeparture = new TimeSpan(23, 30, 0),
                FrequencyMinutes = 15
            };
            route2.GenerateDepartureTimes();
            Routes.Add(route2);

            // Create Employees
            Employees.Add(new Employee
            {
                Id = GetNextEmployeeId(),
                FullName = "John Smith",
                Email = "john.smith@metro.com",
                Phone = "555-0101",
                Role = EmployeeRole.Driver,
                HireDate = new DateTime(2020, 1, 15),
                Salary = 45000
            });

            Employees.Add(new Employee
            {
                Id = GetNextEmployeeId(),
                FullName = "Sarah Johnson",
                Email = "sarah.johnson@metro.com",
                Phone = "555-0102",
                Role = EmployeeRole.Operator,
                HireDate = new DateTime(2019, 6, 1),
                Salary = 38000
            });

            Employees.Add(new Employee
            {
                Id = GetNextEmployeeId(),
                FullName = "Michael Brown",
                Email = "michael.brown@metro.com",
                Phone = "555-0103",
                Role = EmployeeRole.Driver,
                HireDate = new DateTime(2021, 3, 20),
                Salary = 42000
            });

            // Create some sample tickets
            Tickets.Add(new Ticket
            {
                Id = GetNextTicketId(),
                Type = TicketType.Single,
                Price = 2.50m,
                PurchaseDate = DateTime.Now.AddHours(-2),
                PassengerName = "Anonymous",
                FromStationId = station1.Id,
                ToStationId = station2.Id,
                IsUsed = true
            });

            Tickets.Add(new Ticket
            {
                Id = GetNextTicketId(),
                Type = TicketType.Daily,
                Price = 10.00m,
                PurchaseDate = DateTime.Now.AddHours(-1),
                ExpiryDate = DateTime.Now.AddHours(23),
                PassengerName = "Anonymous",
                IsUsed = false
            });

            // Create sample shifts
            Shifts.Add(new Shift
            {
                Id = GetNextShiftId(),
                EmployeeId = Employees[0].Id,
                ShiftDate = DateTime.Today,
                StartTime = new TimeSpan(6, 0, 0),
                EndTime = new TimeSpan(14, 0, 0),
                LineId = line1.Id,
                Notes = "Morning shift"
            });
        }

        // ID Generation Methods
        public int GetNextStationId() => _nextStationId++;
        public int GetNextLineId() => _nextLineId++;
        public int GetNextRouteId() => _nextRouteId++;
        public int GetNextTicketId() => _nextTicketId++;
        public int GetNextEmployeeId() => _nextEmployeeId++;
        public int GetNextShiftId() => _nextShiftId++;
        public int GetNextUserId() => _nextUserId++;

        /// <summary>
        /// Clear all data (useful for testing)
        /// </summary>
        public void ClearAllData()
        {
            Stations.Clear();
            Lines.Clear();
            Routes.Clear();
            Tickets.Clear();
            Employees.Clear();
            Shifts.Clear();
            Users.Clear();

            _nextStationId = 1;
            _nextLineId = 1;
            _nextRouteId = 1;
            _nextTicketId = 1;
            _nextEmployeeId = 1;
            _nextShiftId = 1;
            _nextUserId = 1;
        }
    }
}
