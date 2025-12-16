using metrosistemi.Data;
using metrosistemi.Models;
using metrosistemi.Services;

namespace metrosistemi.Forms
{
    // Route Management Form
    public partial class RouteManagementForm : Form
    {
        public RouteManagementForm()
        {
            InitializeComponent();
            LoadRoutes();
        }

        private void LoadRoutes()
        {
            dgvRoutes.DataSource = null;
            dgvRoutes.DataSource = DataStore.Instance.Routes;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRoutes();
        }

        private void btnViewTimetable_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count > 0)
            {
                var route = (Route)dgvRoutes.SelectedRows[0].DataBoundItem;
                var form = new TimetableViewForm(route);
                form.ShowDialog();
            }
        }
    }

    partial class RouteManagementForm
    {
        private DataGridView dgvRoutes;
        private Panel panelButtons;
        private Button btnViewTimetable, btnRefresh;

        private void InitializeComponent()
        {
            this.dgvRoutes = new DataGridView();
            this.panelButtons = new Panel();
            this.btnViewTimetable = new Button();
            this.btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).BeginInit();

            this.dgvRoutes.AllowUserToAddRows = false;
            this.dgvRoutes.AllowUserToDeleteRows = false;
            this.dgvRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoutes.Dock = DockStyle.Fill;
            this.dgvRoutes.ReadOnly = true;
            this.dgvRoutes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.panelButtons.Controls.AddRange(new Control[] { btnViewTimetable, btnRefresh });
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Size = new Size(800, 50);

            this.btnViewTimetable.Location = new Point(12, 10);
            this.btnViewTimetable.Size = new Size(120, 30);
            this.btnViewTimetable.Text = "View Timetable";
            this.btnViewTimetable.Click += btnViewTimetable_Click;

            this.btnRefresh.Location = new Point(140, 10);
            this.btnRefresh.Size = new Size(100, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += btnRefresh_Click;

            this.ClientSize = new Size(800, 450);
            this.Controls.Add(dgvRoutes);
            this.Controls.Add(panelButtons);
            this.Text = "Route Management";

            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).EndInit();
        }
    }

    // Timetable View Form
    public partial class TimetableViewForm : Form
    {
        private readonly Route _route;

        public TimetableViewForm(Route route)
        {
            InitializeComponent();
            _route = route;
            LoadTimetable();
        }

        private void LoadTimetable()
        {
            lblRouteName.Text = $"Route: {_route.Name}";
            lblFrequency.Text = $"Frequency: Every {_route.FrequencyMinutes} minutes";
            lblFirstDeparture.Text = $"First Departure: {_route.FirstDeparture:hh\\:mm}";
            lblLastDeparture.Text = $"Last Departure: {_route.LastDeparture:hh\\:mm}";

            lstTimetable.Items.Clear();
            foreach (var time in _route.DepartureTimes)
            {
                lstTimetable.Items.Add(time.ToString(@"hh\:mm"));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    partial class TimetableViewForm
    {
        private Label lblRouteName, lblFrequency, lblFirstDeparture, lblLastDeparture;
        private ListBox lstTimetable;
        private Button btnClose;

        private void InitializeComponent()
        {
            this.lblRouteName = new Label();
            this.lblFrequency = new Label();
            this.lblFirstDeparture = new Label();
            this.lblLastDeparture = new Label();
            this.lstTimetable = new ListBox();
            this.btnClose = new Button();

            this.lblRouteName.AutoSize = true;
            this.lblRouteName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblRouteName.Location = new Point(20, 20);

            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new Point(20, 50);

            this.lblFirstDeparture.AutoSize = true;
            this.lblFirstDeparture.Location = new Point(20, 75);

            this.lblLastDeparture.AutoSize = true;
            this.lblLastDeparture.Location = new Point(20, 100);

            this.lstTimetable.Location = new Point(20, 130);
            this.lstTimetable.Size = new Size(360, 200);

            this.btnClose.Location = new Point(290, 350);
            this.btnClose.Size = new Size(90, 30);
            this.btnClose.Text = "Close";
            this.btnClose.Click += btnClose_Click;

            this.ClientSize = new Size(400, 400);
            this.Controls.AddRange(new Control[] {
                lblRouteName, lblFrequency, lblFirstDeparture, lblLastDeparture,
                lstTimetable, btnClose
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Timetable";
        }
    }
}
