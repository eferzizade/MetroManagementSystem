using metrosistemi.Data;
using metrosistemi.Models;
using metrosistemi.Services;

namespace metrosistemi.Forms
{
    // Ticket Sales Form
    public partial class TicketSalesForm : Form
    {
        private readonly TicketService _ticketService;
        private readonly StationService _stationService;

        public TicketSalesForm()
        {
            InitializeComponent();
            _ticketService = new TicketService();
            _stationService = new StationService();
            LoadData();
        }

        private void LoadData()
        {
            cmbTicketType.DataSource = Enum.GetValues(typeof(TicketType));
            var stations = _stationService.GetAllStations();
            cmbFromStation.DataSource = stations.ToList();
            cmbFromStation.DisplayMember = "Name";
            cmbFromStation.ValueMember = "Id";

            cmbToStation.DataSource = stations.ToList();
            cmbToStation.DisplayMember = "Name";
            cmbToStation.ValueMember = "Id";

            UpdatePrice();
        }

        private void cmbTicketType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            if (cmbTicketType.SelectedItem != null)
            {
                var ticketType = (TicketType)cmbTicketType.SelectedItem;
                var price = _ticketService.GetTicketPrice(ticketType);
                lblPrice.Text = $"Price: {price:C}";
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            var ticketType = (TicketType)cmbTicketType.SelectedItem!;
            var passengerName = string.IsNullOrWhiteSpace(txtPassengerName.Text) ? "Anonymous" : txtPassengerName.Text.Trim();

            int? fromStationId = null;
            int? toStationId = null;

            if (ticketType == TicketType.Single && cmbFromStation.SelectedValue != null && cmbToStation.SelectedValue != null)
            {
                fromStationId = (int)cmbFromStation.SelectedValue;
                toStationId = (int)cmbToStation.SelectedValue;
            }

            var ticket = _ticketService.SellTicket(ticketType, passengerName, fromStationId, toStationId);
            MessageBox.Show($"Ticket sold successfully!\nTicket ID: {ticket.Id}\nPrice: {ticket.Price:C}", 
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtPassengerName.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    partial class TicketSalesForm
    {
        private Label lblTicketType, lblPassengerName, lblFromStation, lblToStation, lblPrice;
        private ComboBox cmbTicketType, cmbFromStation, cmbToStation;
        private TextBox txtPassengerName;
        private Button btnSell, btnClose;

        private void InitializeComponent()
        {
            this.lblTicketType = new Label();
            this.cmbTicketType = new ComboBox();
            this.lblPassengerName = new Label();
            this.txtPassengerName = new TextBox();
            this.lblFromStation = new Label();
            this.cmbFromStation = new ComboBox();
            this.lblToStation = new Label();
            this.cmbToStation = new ComboBox();
            this.lblPrice = new Label();
            this.btnSell = new Button();
            this.btnClose = new Button();

            this.lblTicketType.AutoSize = true;
            this.lblTicketType.Location = new Point(20, 20);
            this.lblTicketType.Text = "Ticket Type:";

            this.cmbTicketType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTicketType.Location = new Point(150, 17);
            this.cmbTicketType.Size = new Size(250, 23);
            this.cmbTicketType.SelectedIndexChanged += cmbTicketType_SelectedIndexChanged;

            this.lblPassengerName.AutoSize = true;
            this.lblPassengerName.Location = new Point(20, 60);
            this.lblPassengerName.Text = "Passenger Name:";

            this.txtPassengerName.Location = new Point(150, 57);
            this.txtPassengerName.Size = new Size(250, 23);

            this.lblFromStation.AutoSize = true;
            this.lblFromStation.Location = new Point(20, 100);
            this.lblFromStation.Text = "From Station:";

            this.cmbFromStation.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFromStation.Location = new Point(150, 97);
            this.cmbFromStation.Size = new Size(250, 23);

            this.lblToStation.AutoSize = true;
            this.lblToStation.Location = new Point(20, 140);
            this.lblToStation.Text = "To Station:";

            this.cmbToStation.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbToStation.Location = new Point(150, 137);
            this.cmbToStation.Size = new Size(250, 23);

            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblPrice.Location = new Point(150, 180);
            this.lblPrice.Text = "Price: $0.00";

            this.btnSell.BackColor = Color.Green;
            this.btnSell.ForeColor = Color.White;
            this.btnSell.Location = new Point(150, 220);
            this.btnSell.Size = new Size(120, 35);
            this.btnSell.Text = "Sell Ticket";
            this.btnSell.Click += btnSell_Click;

            this.btnClose.Location = new Point(280, 220);
            this.btnClose.Size = new Size(120, 35);
            this.btnClose.Text = "Close";
            this.btnClose.Click += btnClose_Click;

            this.ClientSize = new Size(450, 280);
            this.Controls.AddRange(new Control[] {
                lblTicketType, cmbTicketType, lblPassengerName, txtPassengerName,
                lblFromStation, cmbFromStation, lblToStation, cmbToStation,
                lblPrice, btnSell, btnClose
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Sell Ticket";
        }
    }

    // Ticket History Form
    public partial class TicketHistoryForm : Form
    {
        private readonly TicketService _ticketService;

        public TicketHistoryForm()
        {
            InitializeComponent();
            _ticketService = new TicketService();
            LoadTickets();
        }

        private void LoadTickets()
        {
            dgvTickets.DataSource = null;
            dgvTickets.DataSource = _ticketService.GetAllTickets();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTickets();
        }
    }

    partial class TicketHistoryForm
    {
        private DataGridView dgvTickets;
        private Panel panelButtons;
        private Button btnRefresh;

        private void InitializeComponent()
        {
            this.dgvTickets = new DataGridView();
            this.panelButtons = new Panel();
            this.btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();

            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AllowUserToDeleteRows = false;
            this.dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTickets.Dock = DockStyle.Fill;
            this.dgvTickets.ReadOnly = true;
            this.dgvTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.panelButtons.Controls.Add(btnRefresh);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Size = new Size(800, 50);

            this.btnRefresh.Location = new Point(12, 10);
            this.btnRefresh.Size = new Size(100, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += btnRefresh_Click;

            this.ClientSize = new Size(800, 450);
            this.Controls.Add(dgvTickets);
            this.Controls.Add(panelButtons);
            this.Text = "Ticket History";

            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
        }
    }
}
