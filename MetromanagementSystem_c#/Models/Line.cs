namespace metrosistemi.Models
{
    /// <summary>
    /// Represents a metro line with ordered stations
    /// </summary>
    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public List<int> StationIds { get; set; }

        public Line()
        {
            Name = string.Empty;
            Color = "#000000";
            StationIds = new List<int>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
