namespace metrosistemi.Forms
{
    partial class MainDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblUser;
        private ToolStripStatusLabel lblRole;
        private ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            statusStrip = new StatusStrip();
            lblUser = new ToolStripStatusLabel();
            lblRole = new ToolStripStatusLabel();
            lblTime = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            timer = new System.Windows.Forms.Timer(components);
            menuStrip = new MenuStrip();
            stationsMenuItem = new ToolStripMenuItem();
            stationsToolStripMenuItem = new ToolStripMenuItem();
            linesToolStripMenuItem = new ToolStripMenuItem();
            routesToolStripMenuItem = new ToolStripMenuItem();
            ticketingMenuItem = new ToolStripMenuItem();
            sellTicketToolStripMenuItem = new ToolStripMenuItem();
            ticketHistoryToolStripMenuItem = new ToolStripMenuItem();
            reportsMenuItem = new ToolStripMenuItem();
            statisticsToolStripMenuItem = new ToolStripMenuItem();
            employeesMenuItem = new ToolStripMenuItem();
            employeesToolStripMenuItem = new ToolStripMenuItem();
            shiftsToolStripMenuItem = new ToolStripMenuItem();
            systemMenuItem = new ToolStripMenuItem();
            userManagementToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            lbl1 = new Label();
            lbl2 = new Label();
            pictureBox1 = new PictureBox();
            lbl3 = new Label();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblUser, lblRole, lblTime, toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 770);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 18, 0);
            statusStrip.Size = new Size(1082, 30);
            statusStrip.TabIndex = 1;
            // 
            // lblUser
            // 
            lblUser.BackColor = Color.DeepSkyBlue;
            lblUser.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.ForeColor = Color.White;
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(54, 24);
            lblUser.Text = "User:";
            // 
            // lblRole
            // 
            lblRole.BackColor = Color.DeepSkyBlue;
            lblRole.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblRole.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.White;
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(58, 24);
            lblRole.Text = "Role:";
            // 
            // lblTime
            // 
            lblTime.BackColor = Color.PaleTurquoise;
            lblTime.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(753, 24);
            lblTime.Spring = true;
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = Color.Turquoise;
            toolStripStatusLabel1.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripStatusLabel1.ForeColor = Color.Black;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(198, 24);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // menuStrip
            // 
            menuStrip.AutoSize = false;
            menuStrip.BackColor = Color.FromArgb(0, 153, 164);
            menuStrip.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { stationsMenuItem, ticketingMenuItem, reportsMenuItem, employeesMenuItem, systemMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(8, 3, 0, 3);
            menuStrip.Size = new Size(1082, 55);
            menuStrip.TabIndex = 0;
            // 
            // stationsMenuItem
            // 
            stationsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { stationsToolStripMenuItem, linesToolStripMenuItem, routesToolStripMenuItem });
            stationsMenuItem.Font = new Font("Consolas", 12F, FontStyle.Bold);
            stationsMenuItem.ForeColor = Color.PaleTurquoise;
            stationsMenuItem.Name = "stationsMenuItem";
            stationsMenuItem.Size = new Size(178, 49);
            stationsMenuItem.Text = "Infrastructure";
            // 
            // stationsToolStripMenuItem
            // 
            stationsToolStripMenuItem.Image = MetroManagement.Properties.Resources.IMG_20251216_WA0001;
            stationsToolStripMenuItem.Name = "stationsToolStripMenuItem";
            stationsToolStripMenuItem.Size = new Size(292, 28);
            stationsToolStripMenuItem.Text = "Stations";
            stationsToolStripMenuItem.Click += stationsToolStripMenuItem_Click;
            // 
            // linesToolStripMenuItem
            // 
            linesToolStripMenuItem.Image = MetroManagement.Properties.Resources.IMG_20251216_WA0010;
            linesToolStripMenuItem.Name = "linesToolStripMenuItem";
            linesToolStripMenuItem.Size = new Size(292, 28);
            linesToolStripMenuItem.Text = "Lines";
            linesToolStripMenuItem.Click += linesToolStripMenuItem_Click;
            // 
            // routesToolStripMenuItem
            // 
            routesToolStripMenuItem.Image = MetroManagement.Properties.Resources.IMG_20251216_WA0004;
            routesToolStripMenuItem.Name = "routesToolStripMenuItem";
            routesToolStripMenuItem.Size = new Size(292, 28);
            routesToolStripMenuItem.Text = "Routes & Timetables";
            routesToolStripMenuItem.Click += routesToolStripMenuItem_Click;
            // 
            // ticketingMenuItem
            // 
            ticketingMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sellTicketToolStripMenuItem, ticketHistoryToolStripMenuItem });
            ticketingMenuItem.Font = new Font("Consolas", 12F, FontStyle.Bold);
            ticketingMenuItem.ForeColor = Color.PaleTurquoise;
            ticketingMenuItem.Name = "ticketingMenuItem";
            ticketingMenuItem.Size = new Size(123, 49);
            ticketingMenuItem.Text = "Ticketing";
            ticketingMenuItem.Click += ticketingMenuItem_Click;
            // 
            // sellTicketToolStripMenuItem
            // 
            sellTicketToolStripMenuItem.Image = MetroManagement.Properties.Resources.IMG_20251216_WA0005;
            sellTicketToolStripMenuItem.Name = "sellTicketToolStripMenuItem";
            sellTicketToolStripMenuItem.Size = new Size(248, 28);
            sellTicketToolStripMenuItem.Text = "Sell Ticket";
            sellTicketToolStripMenuItem.Click += sellTicketToolStripMenuItem_Click;
            // 
            // ticketHistoryToolStripMenuItem
            // 
            ticketHistoryToolStripMenuItem.Image = MetroManagement.Properties.Resources.IMG_20251216_WA0002;
            ticketHistoryToolStripMenuItem.Name = "ticketHistoryToolStripMenuItem";
            ticketHistoryToolStripMenuItem.Size = new Size(248, 28);
            ticketHistoryToolStripMenuItem.Text = "Ticket History";
            ticketHistoryToolStripMenuItem.Click += ticketHistoryToolStripMenuItem_Click;
            // 
            // reportsMenuItem
            // 
            reportsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { statisticsToolStripMenuItem });
            reportsMenuItem.Font = new Font("Consolas", 12F, FontStyle.Bold);
            reportsMenuItem.ForeColor = Color.PaleTurquoise;
            reportsMenuItem.Name = "reportsMenuItem";
            reportsMenuItem.Size = new Size(101, 49);
            reportsMenuItem.Text = "Reports";
            // 
            // statisticsToolStripMenuItem
            // 
            statisticsToolStripMenuItem.Image = MetroManagement.Properties.Resources.IMG_20251216_WA0006;
            statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            statisticsToolStripMenuItem.Size = new Size(224, 28);
            statisticsToolStripMenuItem.Text = "Statistics";
            statisticsToolStripMenuItem.Click += statisticsToolStripMenuItem_Click;
            // 
            // employeesMenuItem
            // 
            employeesMenuItem.DropDownItems.AddRange(new ToolStripItem[] { employeesToolStripMenuItem, shiftsToolStripMenuItem });
            employeesMenuItem.Font = new Font("Consolas", 12F, FontStyle.Bold);
            employeesMenuItem.ForeColor = Color.PaleTurquoise;
            employeesMenuItem.Name = "employeesMenuItem";
            employeesMenuItem.Size = new Size(123, 49);
            employeesMenuItem.Text = "Employees";
            // 
            // employeesToolStripMenuItem
            // 
            employeesToolStripMenuItem.Image = MetroManagement.Properties.Resources.users_avatar;
            employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            employeesToolStripMenuItem.Size = new Size(270, 28);
            employeesToolStripMenuItem.Text = "Manage Employees";
            employeesToolStripMenuItem.Click += employeesToolStripMenuItem_Click;
            // 
            // shiftsToolStripMenuItem
            // 
            shiftsToolStripMenuItem.Image = MetroManagement.Properties.Resources.IMG_20251216_WA0009;
            shiftsToolStripMenuItem.Name = "shiftsToolStripMenuItem";
            shiftsToolStripMenuItem.Size = new Size(270, 28);
            shiftsToolStripMenuItem.Text = "Shifts";
            shiftsToolStripMenuItem.Click += shiftsToolStripMenuItem_Click;
            // 
            // systemMenuItem
            // 
            systemMenuItem.DropDownItems.AddRange(new ToolStripItem[] { userManagementToolStripMenuItem, exitToolStripMenuItem });
            systemMenuItem.Font = new Font("Consolas", 12F, FontStyle.Bold);
            systemMenuItem.ForeColor = Color.PaleTurquoise;
            systemMenuItem.Name = "systemMenuItem";
            systemMenuItem.Size = new Size(90, 49);
            systemMenuItem.Text = "System";
            systemMenuItem.Click += systemMenuItem_Click;
            // 
            // userManagementToolStripMenuItem
            // 
            userManagementToolStripMenuItem.Image = MetroManagement.Properties.Resources.IMG_20251216_WA0007;
            userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            userManagementToolStripMenuItem.Size = new Size(259, 28);
            userManagementToolStripMenuItem.Text = "User Management";
            userManagementToolStripMenuItem.Click += userManagementToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = MetroManagement.Properties.Resources.log_in;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(259, 28);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.BackColor = Color.FromArgb(240, 243, 247);
            lbl1.Font = new Font("Consolas", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.ForeColor = Color.FromArgb(0, 64, 64);
            lbl1.Location = new Point(319, 88);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(416, 40);
            lbl1.TabIndex = 4;
            lbl1.Text = "Welcome to the System";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Consolas", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl2.ForeColor = Color.Teal;
            lbl2.Location = new Point(8, 176);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(441, 27);
            lbl2.TabIndex = 5;
            lbl2.Text = "You have successfully logged in. ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = MetroManagement.Properties.Resources.train;
            pictureBox1.Location = new Point(838, 118);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(211, 118);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Font = new Font("Consolas", 13.8F);
            lbl3.ForeColor = Color.Teal;
            lbl3.Location = new Point(8, 212);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(727, 27);
            lbl3.TabIndex = 7;
            lbl3.Text = "Use the menu or click on sections to manage the system.";
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1082, 800);
            Controls.Add(lbl3);
            Controls.Add(statusStrip);
            Controls.Add(pictureBox1);
            Controls.Add(lbl2);
            Controls.Add(menuStrip);
            Controls.Add(lbl1);
            Cursor = Cursors.Hand;
            Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Metro Management System - Dashboard";
            Load += MainDashboard_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private ToolStripStatusLabel toolStripStatusLabel1;
        private MenuStrip menuStrip;
        private ToolStripMenuItem stationsMenuItem;
        private ToolStripMenuItem stationsToolStripMenuItem;
        private ToolStripMenuItem linesToolStripMenuItem;
        private ToolStripMenuItem routesToolStripMenuItem;
        private ToolStripMenuItem ticketingMenuItem;
        private ToolStripMenuItem sellTicketToolStripMenuItem;
        private ToolStripMenuItem ticketHistoryToolStripMenuItem;
        private ToolStripMenuItem reportsMenuItem;
        private ToolStripMenuItem statisticsToolStripMenuItem;
        private ToolStripMenuItem employeesMenuItem;
        private ToolStripMenuItem employeesToolStripMenuItem;
        private ToolStripMenuItem shiftsToolStripMenuItem;
        private ToolStripMenuItem systemMenuItem;
        private ToolStripMenuItem userManagementToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label lbl1;
        private Label lbl2;
        private PictureBox pictureBox1;
        private Label lbl3;
    }
}
