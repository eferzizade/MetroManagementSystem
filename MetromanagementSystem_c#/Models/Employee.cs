namespace metrosistemi.Models
{
    /// <summary>
    /// Employee roles in the metro system
    /// </summary>
    public enum EmployeeRole
    {
        Operator,
        Driver,
        Maintenance,
        Security,
        Manager
    }

    /// <summary>
    /// Represents an employee in the metro system
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public EmployeeRole Role { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public Employee()
        {
            FullName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            HireDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{FullName} ({Role})";
        }
    }
}
