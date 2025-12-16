using metrosistemi.Data;
using metrosistemi.Models;
using metrosistemi.Services;
using System.Text;

namespace metrosistemi.Forms
{
    // Statistics Form
    public partial class StatisticsForm : Form
    {
        private readonly TicketService _ticketService;

        public StatisticsForm()
        {
            InitializeComponent();
            _ticketService = new TicketService();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            // Total Revenue
            var totalRevenue = _ticketService.GetTotalRevenue();
            lblTotalRevenue.Text = $"Total Revenue: {totalRevenue:C}";

            // Today's Sales
            var todaySales = _ticketService.GetTotalSalesForDate(DateTime.Today);
            lblTodaySales.Text = $"Today's Sales: {todaySales:C}";

            // Ticket Count
            var ticketCount = _ticketService.GetAllTickets().Count;
            lblTicketCount.Text = $"Total Tickets Sold: {ticketCount}";

            // Sales by Type
            var salesByType = _ticketService.GetTicketSalesByType();
            lstSalesByType.Items.Clear();
            foreach (var item in salesByType)
            {
                lstSalesByType.Items.Add($"{item.Key}: {item.Value} tickets");
            }

            // Hourly Sales for Today
            var hourlySales = _ticketService.GetHourlySales(DateTime.Today);
            lstHourlySales.Items.Clear();
            foreach (var hour in hourlySales.Where(h => h.Value > 0))
            {
                lstHourlySales.Items.Add($"{hour.Key:D2}:00 - {hour.Value} tickets");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            var report = new StringBuilder();
            report.AppendLine("METRO MANAGEMENT SYSTEM - STATISTICS REPORT");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            report.AppendLine(new string('=', 50));
            report.AppendLine();
            report.AppendLine(lblTotalRevenue.Text);
            report.AppendLine(lblTodaySales.Text);
            report.AppendLine(lblTicketCount.Text);
            report.AppendLine();
            report.AppendLine("Sales by Ticket Type:");
            foreach (var item in lstSalesByType.Items)
            {
                report.AppendLine($"  {item}");
            }

            MessageBox.Show(report.ToString(), "Statistics Report", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    partial class StatisticsForm
    {
        private Label lblTotalRevenue, lblTodaySales, lblTicketCount;
        private Label lblSalesByType, lblHourlySales;
        private ListBox lstSalesByType, lstHourlySales;
        private Button btnRefresh, btnPrintReport;

        private void InitializeComponent()
        {
            this.lblTotalRevenue = new Label();
            this.lblTodaySales = new Label();
            this.lblTicketCount = new Label();
            this.lblSalesByType = new Label();
            this.lstSalesByType = new ListBox();
            this.lblHourlySales = new Label();
            this.lstHourlySales = new ListBox();
            this.btnRefresh = new Button();
            this.btnPrintReport = new Button();

            // lblTotalRevenue
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTotalRevenue.Location = new Point(20, 20);

            // lblTodaySales
            this.lblTodaySales.AutoSize = true;
            this.lblTodaySales.Font = new Font("Segoe UI", 11F);
            this.lblTodaySales.Location = new Point(20, 50);

            // lblTicketCount
            this.lblTicketCount.AutoSize = true;
            this.lblTicketCount.Font = new Font("Segoe UI", 11F);
            this.lblTicketCount.Location = new Point(20, 75);

            // lblSalesByType
            this.lblSalesByType.AutoSize = true;
            this.lblSalesByType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSalesByType.Location = new Point(20, 110);
            this.lblSalesByType.Text = "Sales by Ticket Type:";

            // lstSalesByType
            this.lstSalesByType.Location = new Point(20, 135);
            this.lstSalesByType.Size = new Size(250, 150);

            // lblHourlySales
            this.lblHourlySales.AutoSize = true;
            this.lblHourlySales.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblHourlySales.Location = new Point(300, 110);
            this.lblHourlySales.Text = "Today's Hourly Sales:";

            // lstHourlySales
            this.lstHourlySales.Location = new Point(300, 135);
            this.lstHourlySales.Size = new Size(250, 150);

            // btnRefresh
            this.btnRefresh.Location = new Point(20, 300);
            this.btnRefresh.Size = new Size(120, 35);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += btnRefresh_Click;

            // btnPrintReport
            this.btnPrintReport.Location = new Point(150, 300);
            this.btnPrintReport.Size = new Size(120, 35);
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.Click += btnPrintReport_Click;

            // StatisticsForm
            this.ClientSize = new Size(600, 360);
            this.Controls.AddRange(new Control[] {
                lblTotalRevenue, lblTodaySales, lblTicketCount,
                lblSalesByType, lstSalesByType,
                lblHourlySales, lstHourlySales,
                btnRefresh, btnPrintReport
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Statistics & Reports";
        }
    }
}
