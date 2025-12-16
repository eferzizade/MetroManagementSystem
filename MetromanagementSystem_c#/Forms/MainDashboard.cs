using metrosistemi.Services;

namespace metrosistemi.Forms
{
    public partial class MainDashboard : Form
    {
        private readonly AuthService _authService;

        public MainDashboard(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            ConfigureMenuAccess();
            UpdateStatusBar();
        }

        private void ConfigureMenuAccess()
        {
            // Operators have limited access
            if (!_authService.IsAdmin())
            {
                employeesToolStripMenuItem.Enabled = false;
                userManagementToolStripMenuItem.Enabled = false;
            }
        }

        private void UpdateStatusBar()
        {
            lblUser.Text = $"User: {_authService.CurrentUser?.FullName ?? "Unknown"}";
            lblRole.Text = $"Role: {_authService.CurrentUser?.Role.ToString() ?? "Unknown"}";
            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        // Menu Click Handlers
        private void stationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Visible = false;
            menuStrip.Location = new Point(0, 0);
            var form = new StationManagementForm();
            form.MdiParent = this;
            form.Show();
        }

        private void linesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Visible = false;
            menuStrip.Location = new Point(0, 0);
            var form = new LineManagementForm();
            form.MdiParent = this;
            form.Show();
        }

        private void routesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Visible = false;
            menuStrip.Location = new Point(0, 0);
            var form = new RouteManagementForm();
            form.MdiParent = this;
            form.Show();
        }

        private void sellTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Visible = false;
            menuStrip.Location = new Point(0, 0);
            var form = new TicketSalesForm();
            form.MdiParent = this;
            form.Show();
        }

        private void ticketHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Visible = false;
            menuStrip.Location = new Point(0, 0);
            var form = new TicketHistoryForm();
            form.MdiParent = this;
            form.Show();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Visible = false;
            menuStrip.Location = new Point(0, 0);
            var form = new StatisticsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Visible = false;
            menuStrip.Location = new Point(0, 0);
            var form = new EmployeeManagementForm();
            form.MdiParent = this;
            form.Show();
        }

        private void shiftsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Visible = false;
            menuStrip.Location = new Point(0, 0);
            var form = new ShiftManagementForm();
            form.MdiParent = this;
            form.Show();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Visible = false;
            menuStrip.Location = new Point(0, 0);
            var form = new UserManagementForm(_authService);
            form.MdiParent = this;
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            pictureBox1.Visible = false;
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome!";
        }

        private void systemMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ticketingMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
