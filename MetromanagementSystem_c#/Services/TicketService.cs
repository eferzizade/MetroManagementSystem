using metrosistemi.Data;
using metrosistemi.Models;

namespace metrosistemi.Services
{
    /// <summary>
    /// Service for managing ticket sales and statistics
    /// </summary>
    public class TicketService
    {
        private readonly DataStore _dataStore;

        public TicketService()
        {
            _dataStore = DataStore.Instance;
        }

        /// <summary>
        /// Get all tickets
        /// </summary>
        public List<Ticket> GetAllTickets()
        {
            return _dataStore.Tickets;
        }

        /// <summary>
        /// Get tickets by date range
        /// </summary>
        public List<Ticket> GetTicketsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dataStore.Tickets
                .Where(t => t.PurchaseDate >= startDate && t.PurchaseDate <= endDate)
                .ToList();
        }

        /// <summary>
        /// Get tickets by type
        /// </summary>
        public List<Ticket> GetTicketsByType(TicketType type)
        {
            return _dataStore.Tickets.Where(t => t.Type == type).ToList();
        }

        /// <summary>
        /// Sell a new ticket
        /// </summary>
        public Ticket SellTicket(TicketType type, string passengerName, int? fromStationId = null, int? toStationId = null)
        {
            var ticket = new Ticket
            {
                Id = _dataStore.GetNextTicketId(),
                Type = type,
                Price = GetTicketPrice(type),
                PurchaseDate = DateTime.Now,
                PassengerName = passengerName,
                FromStationId = fromStationId,
                ToStationId = toStationId,
                IsUsed = false
            };

            // Set expiry date based on ticket type
            switch (type)
            {
                case TicketType.Daily:
                    ticket.ExpiryDate = DateTime.Now.AddDays(1);
                    break;
                case TicketType.Weekly:
                    ticket.ExpiryDate = DateTime.Now.AddDays(7);
                    break;
                case TicketType.Monthly:
                    ticket.ExpiryDate = DateTime.Now.AddMonths(1);
                    break;
                case TicketType.Subscription:
                    ticket.ExpiryDate = DateTime.Now.AddMonths(1);
                    break;
            }

            _dataStore.Tickets.Add(ticket);
            return ticket;
        }

        /// <summary>
        /// Get ticket price based on type
        /// </summary>
        public decimal GetTicketPrice(TicketType type)
        {
            return type switch
            {
                TicketType.Single => 2.50m,
                TicketType.Daily => 10.00m,
                TicketType.Weekly => 50.00m,
                TicketType.Monthly => 150.00m,
                TicketType.Subscription => 180.00m,
                _ => 0m
            };
        }

        /// <summary>
        /// Get total sales for a date
        /// </summary>
        public decimal GetTotalSalesForDate(DateTime date)
        {
            return _dataStore.Tickets
                .Where(t => t.PurchaseDate.Date == date.Date)
                .Sum(t => t.Price);
        }

        /// <summary>
        /// Get hourly sales statistics
        /// </summary>
        public Dictionary<int, int> GetHourlySales(DateTime date)
        {
            var hourlySales = new Dictionary<int, int>();
            
            for (int hour = 0; hour < 24; hour++)
            {
                hourlySales[hour] = 0;
            }

            var tickets = _dataStore.Tickets
                .Where(t => t.PurchaseDate.Date == date.Date)
                .ToList();

            foreach (var ticket in tickets)
            {
                hourlySales[ticket.PurchaseDate.Hour]++;
            }

            return hourlySales;
        }

        /// <summary>
        /// Get daily sales statistics for a month
        /// </summary>
        public Dictionary<DateTime, decimal> GetDailySales(int year, int month)
        {
            var dailySales = new Dictionary<DateTime, decimal>();
            var daysInMonth = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                var date = new DateTime(year, month, day);
                dailySales[date] = GetTotalSalesForDate(date);
            }

            return dailySales;
        }

        /// <summary>
        /// Get ticket sales by type
        /// </summary>
        public Dictionary<TicketType, int> GetTicketSalesByType()
        {
            return _dataStore.Tickets
                .GroupBy(t => t.Type)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Get total revenue
        /// </summary>
        public decimal GetTotalRevenue()
        {
            return _dataStore.Tickets.Sum(t => t.Price);
        }
    }
}
