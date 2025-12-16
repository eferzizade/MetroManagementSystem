# Metro Management System

A comprehensive Windows Forms desktop application for managing metro/subway operations, built with C# and .NET 8.0.

## 📋 Project Overview

This is a university-level course project that simulates a complete metro management system without using any database. All data is stored in-memory using collections (List<T>, Dictionary) and managed through a centralized DataStore singleton.

## ✨ Features

### 1. **User Authentication**
- Role-based access control (Admin/Operator)
- Simple login system with password protection
- Default credentials:
  - **Admin**: username: `admin`, password: `admin123`
  - **Operator**: username: `operator`, password: `operator123`

### 2. **Station Management**
- Add, Edit, Delete, and View stations
- Station properties: Name, Address, GPS Coordinates (Latitude/Longitude), Line assignment
- Search and filter capabilities

### 3. **Line Management**
- Create and manage metro lines
- Assign colors to lines
- Ordered list of stations per line
- View line details and associated stations

### 4. **Routes & Timetables**
- Define train routes for each line
- Set departure times and frequency (e.g., every 10 minutes)
- Automatic timetable generation based on frequency
- View complete timetables for any route

### 5. **Ticketing System**
- Ticket types:
  - Single ticket ($2.50)
  - Daily pass ($10.00)
  - Weekly pass ($50.00)
  - Monthly pass ($150.00)
  - Subscription ($180.00)
- Simulated payment (no real payment gateway)
- Track ticket sales and history
- Passenger information recording

### 6. **Statistics & Reports**
- Real-time revenue tracking
- Daily and hourly sales statistics
- Ticket sales by type
- Passenger flow analysis
- Simple report generation with print preview

### 7. **Employee Management**
- Employee roles: Operator, Driver, Maintenance, Security, Manager
- Track employee details: Name, Email, Phone, Hire Date, Salary
- Shift scheduling and management
- View employee work hours

### 8. **User Management** (Admin only)
- Create and manage system users
- Assign roles (Admin/Operator)
- View user information

## 🏗️ Architecture

### Project Structure

```
metrosistemi/
├── Models/                    # Data models
│   ├── Station.cs
│   ├── Line.cs
│   ├── Route.cs
│   ├── Ticket.cs
│   ├── Employee.cs
│   ├── Shift.cs
│   └── User.cs
├── Data/                      # Data storage
│   └── DataStore.cs          # Singleton in-memory data store
├── Services/                  # Business logic
│   ├── AuthService.cs
│   ├── StationService.cs
│   ├── TicketService.cs
│   └── EmployeeService.cs
├── Forms/                     # UI Forms
│   ├── LoginForm.cs
│   ├── MainDashboard.cs
│   ├── StationManagementForm.cs
│   ├── TicketSalesForm.cs
│   ├── StatisticsForm.cs
│   └── ... (other forms)
└── Program.cs                 # Application entry point
```

### Key Design Principles

1. **No Database**: All data is stored in-memory using C# collections
2. **Singleton Pattern**: DataStore uses singleton pattern for centralized data access
3. **Service Layer**: Business logic separated into service classes
4. **Model-View Separation**: Clear separation between data models and UI
5. **Role-Based Access**: Different access levels for Admin and Operator roles

## 🚀 How to Run

### Prerequisites
- Windows 10/11
- .NET 8.0 SDK or later
- Visual Studio 2022 (or Visual Studio Code with C# extension)

### Running the Application

1. **Open the project**:
   ```bash
   cd c:\Users\aliye\Desktop\metrosistemi
   ```

2. **Build and run**:
   - **Using Visual Studio**: Open `metrosistemi.sln`, press F5
   - **Using command line**:
     ```powershell
     dotnet build
     dotnet run
     ```

3. **Login**:
   - Use default credentials (see above)
   - Admin has full access, Operator has limited access

## 📊 Sample Data

The system comes pre-loaded with sample data:

- **3 Metro Lines**: Red Line, Blue Line, Green Line
- **5 Stations**: Central Station, North Terminal, South Terminal, East Station, West Station
- **2 Routes**: Red Line Morning, Blue Line All Day
- **3 Employees**: Drivers and Operators with different roles
- **Sample Tickets**: A few pre-generated tickets for testing
- **Sample Shifts**: One shift assigned to demonstrate the system

## 🎯 Usage Guide

### For Administrators

1. **Login** as admin
2. **Manage Infrastructure**:
   - Add/Edit/Delete Stations
   - Create and configure Lines
   - Set up Routes and Timetables
3. **Manage Personnel**:
   - Add/Edit Employees
   - Assign Shifts
   - Manage Users
4. **View Reports**:
   - Check statistics
   - Generate reports

### For Operators

1. **Login** as operator
2. **Sell Tickets**:
   - Select ticket type
   - Enter passenger information
   - Process sale
3. **View Information**:
   - Check timetables
   - View station information
   - See ticket history
4. **View Statistics**:
   - Sales reports
   - Passenger flow

## 💾 Data Persistence

**Important**: This application does NOT use a database. All data is stored in-memory and will be lost when the application closes.

### Optional Enhancement
If you need data persistence, you can easily add JSON serialization:
1. Serialize DataStore to JSON file on application close
2. Deserialize from JSON file on application start
3. Use System.Text.Json or Newtonsoft.Json library

## 🔧 Technical Details

### Technologies Used
- **Framework**: .NET 8.0
- **UI**: Windows Forms
- **Language**: C# 12
- **Architecture**: Layered (Models, Services, Forms)
- **Design Patterns**: Singleton, Service Layer

### Key Classes

- **DataStore**: Centralized in-memory data management
- **AuthService**: User authentication and authorization
- **StationService**: Station CRUD operations
- **TicketService**: Ticket sales and statistics
- **EmployeeService**: Employee and shift management

## 📝 Notes for Academic Use

This project demonstrates:
- ✅ Object-Oriented Programming principles
- ✅ Layered architecture design
- ✅ Windows Forms UI development
- ✅ In-memory data management
- ✅ Role-based access control
- ✅ CRUD operations without database
- ✅ Clean, readable, and well-commented code

## 🎓 Learning Outcomes

Students working with this project will learn:
1. Windows Forms application development
2. Data management without databases
3. Service-oriented architecture
4. User authentication and authorization
5. CRUD operations implementation
6. Event-driven programming
7. Object-oriented design principles

## 📞 Default Login Credentials

| Username  | Password     | Role     | Access Level |
|-----------|-------------|----------|--------------|
| admin     | admin123    | Admin    | Full Access  |
| operator  | operator123 | Operator | Limited      |

## 🔐 Security Note

This is a **demonstration/educational project**. The authentication system uses plain-text password storage and is NOT suitable for production use. In a real-world application, you should:
- Hash passwords using bcrypt or similar
- Use secure session management
- Implement proper authorization checks
- Add input validation and sanitization

## 📄 License

This is an educational project created for university coursework.

---

**Developed as a university course project - Metro Management System Simulation**
