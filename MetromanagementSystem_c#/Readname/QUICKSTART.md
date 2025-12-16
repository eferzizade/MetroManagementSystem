# Quick Start Guide - Metro Management System

## 🚀 Getting Started in 3 Steps

### Step 1: Run the Application

```powershell
# Navigate to the project directory
cd c:\Users\aliye\Desktop\metrosistemi

# Run the application
dotnet run
```

Or simply open `metrosistemi.sln` in Visual Studio and press **F5**.

---

### Step 2: Login

When the application starts, you'll see a login screen.

**Default Credentials:**

| Role     | Username  | Password     |
|----------|-----------|--------------|
| Admin    | `admin`   | `admin123`   |
| Operator | `operator`| `operator123`|

**Note:** Admin users have full access to all features. Operators have limited access.

---

### Step 3: Explore the System

After logging in, you'll see the main dashboard with a menu bar containing:

#### 📍 **Infrastructure Menu**
- **Stations** - View, add, edit, and delete metro stations
- **Lines** - Manage metro lines and assign colors
- **Routes & Timetables** - Configure train schedules

#### 🎫 **Ticketing Menu**
- **Sell Ticket** - Process ticket sales (Single, Daily, Weekly, Monthly, Subscription)
- **Ticket History** - View all ticket transactions

#### 📊 **Reports Menu**
- **Statistics** - View sales statistics, revenue, and passenger flow

#### 👥 **Employees Menu** (Admin only)
- **Manage Employees** - Add/edit employee information
- **Shifts** - View and manage work shifts

#### ⚙️ **System Menu**
- **User Management** (Admin only) - Manage system users
- **Exit** - Close the application

---

## 📝 Common Tasks

### How to Sell a Ticket

1. Go to **Ticketing → Sell Ticket**
2. Select ticket type from dropdown
3. Enter passenger name (optional)
4. For single tickets, select From/To stations
5. Click **Sell Ticket**
6. A confirmation message will show the ticket ID and price

### How to Add a New Station

1. Go to **Infrastructure → Stations**
2. Click **Add Station**
3. Fill in:
   - Station Name
   - Address
   - Latitude (e.g., 41.0082)
   - Longitude (e.g., 28.9784)
   - Select a Line from dropdown
4. Click **Save**

### How to View Statistics

1. Go to **Reports → Statistics**
2. View:
   - Total revenue
   - Today's sales
   - Ticket count
   - Sales by ticket type
   - Hourly sales for today
3. Click **Print Report** to generate a text report

### How to Add an Employee (Admin only)

1. Go to **Employees → Manage Employees**
2. Click **Add Employee**
3. Fill in employee details:
   - Full Name
   - Email
   - Phone
   - Role (Operator, Driver, Maintenance, Security, Manager)
   - Hire Date
   - Salary
4. Click **Save**

### How to View Train Timetables

1. Go to **Infrastructure → Routes & Timetables**
2. Select a route from the list
3. Click **View Timetable**
4. See all departure times for that route

---

## 📦 Sample Data Included

The system comes pre-loaded with:

- ✅ 3 Metro Lines (Red, Blue, Green)
- ✅ 5 Stations
- ✅ 2 Routes with generated timetables
- ✅ 3 Employees (Drivers and Operators)
- ✅ Sample tickets
- ✅ Sample shift assignments

---

## 💡 Tips

1. **Data is in-memory**: All data is lost when you close the application
2. **Role-based access**: Login as admin to access all features
3. **Navigation**: Use the top menu bar to navigate between modules
4. **Child windows**: Most forms open as child windows within the main dashboard (MDI)
5. **Refresh buttons**: Click refresh to update data grids with latest information

---

## 🔧 Troubleshooting

### Problem: Application won't start
**Solution**: Make sure you have .NET 8.0 SDK installed. Run `dotnet --version` to check.

### Problem: Can't login
**Solution**: Use the exact credentials:
- Username: `admin` (lowercase)
- Password: `admin123`

### Problem: Menu items are disabled
**Solution**: You're logged in as Operator. Some features are Admin-only. Logout and login as admin.

### Problem: Build errors
**Solution**: Run `dotnet clean` then `dotnet build` again.

---

## 📚 For More Information

See **README.md** for:
- Complete feature list
- Architecture details
- Technical documentation
- Learning outcomes

---

## 🎓 Academic Use

This project demonstrates:
- Windows Forms development
- In-memory data management
- Service-oriented architecture
- Role-based access control
- CRUD operations without a database

**Perfect for**: University course projects, learning C# and Windows Forms, understanding layered architecture.

---

**Enjoy exploring the Metro Management System! 🚇**
