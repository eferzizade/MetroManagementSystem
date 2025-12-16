namespace metrosistemi.Models
{
    /// <summary>
    /// Ticket types available in the system
    /// </summary>
    public enum TicketType
    {
        Single,
        Daily,
        Weekly,
        Monthly,
        Subscription
    }

    /// <summary>
    /// Represents a ticket purchase
    /// </summary>
    public class Ticket
    {
        public int Id { get; set; }
        public TicketType Type { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string PassengerName { get; set; }
        public int? FromStationId { get; set; }
        public int? ToStationId { get; set; }
        public bool IsUsed { get; set; }

        public Ticket()
        {
            PurchaseDate = DateTime.Now;
            PassengerName = "Anonymous";
            IsUsed = false;
        }

        public override string ToString()
        {
            return $"{Type} - {Price:C}";
        }
    }
}
