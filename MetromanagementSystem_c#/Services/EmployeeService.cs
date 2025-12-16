using metrosistemi.Data;
using metrosistemi.Models;

namespace metrosistemi.Services
{
    /// <summary>
    /// Service for managing employees and shifts
    /// </summary>
    public class EmployeeService
    {
        private readonly DataStore _dataStore;

        public EmployeeService()
        {
            _dataStore = DataStore.Instance;
        }

        // Employee Management
        public List<Employee> GetAllEmployees()
        {
            return _dataStore.Employees;
        }

        public Employee? GetEmployeeById(int id)
        {
            return _dataStore.Employees.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetEmployeesByRole(EmployeeRole role)
        {
            return _dataStore.Employees.Where(e => e.Role == role).ToList();
        }

        public void AddEmployee(Employee employee)
        {
            employee.Id = _dataStore.GetNextEmployeeId();
            _dataStore.Employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var existing = _dataStore.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null)
            {
                existing.FullName = employee.FullName;
                existing.Email = employee.Email;
                existing.Phone = employee.Phone;
                existing.Role = employee.Role;
                existing.HireDate = employee.HireDate;
                existing.Salary = employee.Salary;
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _dataStore.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (employee != null)
            {
                // Remove associated shifts
                _dataStore.Shifts.RemoveAll(s => s.EmployeeId == employeeId);
                _dataStore.Employees.Remove(employee);
            }
        }

        // Shift Management
        public List<Shift> GetAllShifts()
        {
            return _dataStore.Shifts;
        }

        public List<Shift> GetShiftsByEmployee(int employeeId)
        {
            return _dataStore.Shifts.Where(s => s.EmployeeId == employeeId).ToList();
        }

        public List<Shift> GetShiftsByDate(DateTime date)
        {
            return _dataStore.Shifts.Where(s => s.ShiftDate.Date == date.Date).ToList();
        }

        public List<Shift> GetShiftsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dataStore.Shifts
                .Where(s => s.ShiftDate >= startDate && s.ShiftDate <= endDate)
                .ToList();
        }

        public void AddShift(Shift shift)
        {
            shift.Id = _dataStore.GetNextShiftId();
            _dataStore.Shifts.Add(shift);
        }

        public void UpdateShift(Shift shift)
        {
            var existing = _dataStore.Shifts.FirstOrDefault(s => s.Id == shift.Id);
            if (existing != null)
            {
                existing.EmployeeId = shift.EmployeeId;
                existing.ShiftDate = shift.ShiftDate;
                existing.StartTime = shift.StartTime;
                existing.EndTime = shift.EndTime;
                existing.LineId = shift.LineId;
                existing.Notes = shift.Notes;
            }
        }

        public void DeleteShift(int shiftId)
        {
            var shift = _dataStore.Shifts.FirstOrDefault(s => s.Id == shiftId);
            if (shift != null)
            {
                _dataStore.Shifts.Remove(shift);
            }
        }

        /// <summary>
        /// Get total hours worked by an employee in a date range
        /// </summary>
        public double GetTotalHoursWorked(int employeeId, DateTime startDate, DateTime endDate)
        {
            var shifts = GetShiftsByDateRange(startDate, endDate)
                .Where(s => s.EmployeeId == employeeId)
                .ToList();

            return shifts.Sum(s => s.Duration.TotalHours);
        }
    }
}
