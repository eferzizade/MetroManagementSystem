namespace metrosistemi.Models
{
    /// <summary>
    /// Represents a work shift for employees
    /// </summary>
    public class Shift
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int? LineId { get; set; }
        public string Notes { get; set; }

        public Shift()
        {
            ShiftDate = DateTime.Today;
            Notes = string.Empty;
        }

        public TimeSpan Duration => EndTime - StartTime;

        public override string ToString()
        {
            return $"{ShiftDate:yyyy-MM-dd} {StartTime:hh\\:mm} - {EndTime:hh\\:mm}";
        }
    }
}
