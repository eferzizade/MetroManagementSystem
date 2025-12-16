namespace metrosistemi.Models
{
    /// <summary>
    /// Represents a train route with timetable information
    /// </summary>
    public class Route
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public string Name { get; set; }
        public TimeSpan FirstDeparture { get; set; }
        public TimeSpan LastDeparture { get; set; }
        public int FrequencyMinutes { get; set; }
        public List<TimeSpan> DepartureTimes { get; set; }

        public Route()
        {
            Name = string.Empty;
            DepartureTimes = new List<TimeSpan>();
            FrequencyMinutes = 10;
        }

        /// <summary>
        /// Generates departure times based on frequency
        /// </summary>
        public void GenerateDepartureTimes()
        {
            DepartureTimes.Clear();
            TimeSpan current = FirstDeparture;
            while (current <= LastDeparture)
            {
                DepartureTimes.Add(current);
                current = current.Add(TimeSpan.FromMinutes(FrequencyMinutes));
            }
        }
    }
}
