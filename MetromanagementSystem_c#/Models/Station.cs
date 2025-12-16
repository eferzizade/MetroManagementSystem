namespace metrosistemi.Models
{
    /// <summary>
    /// Represents a metro station
    /// </summary>
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int LineId { get; set; }

        public Station()
        {
            Name = string.Empty;
            Address = string.Empty;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
