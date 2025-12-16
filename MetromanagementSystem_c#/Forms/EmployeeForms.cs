using metrosistemi.Data;
using metrosistemi.Models;
using metrosistemi.Services;

namespace metrosistemi.Forms
{
    // Employee Management Form
    public partial class EmployeeManagementForm : Form
    {
        private readonly EmployeeService _employeeService;

        public EmployeeManagementForm()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = _employeeService.GetAllEmployees();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EmployeeEditForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadEmployees();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var employee = (Employee)dgvEmployees.SelectedRows[0].DataBoundItem;
                var form = new EmployeeEditForm(employee);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadEmployees();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var employee = (Employee)dgvEmployees.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"Delete employee '{employee.FullName}'?", "Confirm", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _employeeService.DeleteEmployee(employee.Id);
                    LoadEmployees();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }
    }

    partial class EmployeeManagementForm
    {
        private DataGridView dgvEmployees;
        private Panel panelButtons;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh;

        private void InitializeComponent()
        {
            this.dgvEmployees = new DataGridView();
            this.panelButtons = new Panel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();

            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.Dock = DockStyle.Fill;
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.panelButtons.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh });
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Size = new Size(800, 50);

            this.btnAdd.Location = new Point(12, 10);
            this.btnAdd.Size = new Size(100, 30);
            this.btnAdd.Text = "Add Employee";
            this.btnAdd.Click += btnAdd_Click;

            this.btnEdit.Location = new Point(120, 10);
            this.btnEdit.Size = new Size(100, 30);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += btnEdit_Click;

            this.btnDelete.Location = new Point(228, 10);
            this.btnDelete.Size = new Size(100, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += btnDelete_Click;

            this.btnRefresh.Location = new Point(336, 10);
            this.btnRefresh.Size = new Size(100, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += btnRefresh_Click;

            this.ClientSize = new Size(800, 450);
            this.Controls.Add(dgvEmployees);
            this.Controls.Add(panelButtons);
            this.Text = "Employee Management";

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
        }
    }

    // Employee Edit Form
    public partial class EmployeeEditForm : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly Employee? _employee;
        private readonly bool _isEditMode;

        public EmployeeEditForm(Employee? employee = null)
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _employee = employee;
            _isEditMode = employee != null;

            cmbRole.DataSource = Enum.GetValues(typeof(EmployeeRole));

            if (_isEditMode && _employee != null)
            {
                txtFullName.Text = _employee.FullName;
                txtEmail.Text = _employee.Email;
                txtPhone.Text = _employee.Phone;
                cmbRole.SelectedItem = _employee.Role;
                dtpHireDate.Value = _employee.HireDate;
                txtSalary.Text = _employee.Salary.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter full name.");
                return;
            }

            if (!decimal.TryParse(txtSalary.Text, out decimal salary))
            {
                MessageBox.Show("Please enter valid salary.");
                return;
            }

            var employee = _employee ?? new Employee();
            employee.FullName = txtFullName.Text.Trim();
            employee.Email = txtEmail.Text.Trim();
            employee.Phone = txtPhone.Text.Trim();
            employee.Role = (EmployeeRole)cmbRole.SelectedItem!;
            employee.HireDate = dtpHireDate.Value;
            employee.Salary = salary;

            if (_isEditMode)
                _employeeService.UpdateEmployee(employee);
            else
                _employeeService.AddEmployee(employee);

            MessageBox.Show("Employee saved successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    partial class EmployeeEditForm
    {
        private Label lblFullName, lblEmail, lblPhone, lblRole, lblHireDate, lblSalary;
        private TextBox txtFullName, txtEmail, txtPhone, txtSalary;
        private ComboBox cmbRole;
        private DateTimePicker dtpHireDate;
        private Button btnSave, btnCancel;

        private void InitializeComponent()
        {
            this.lblFullName = new Label();
            this.txtFullName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblRole = new Label();
            this.cmbRole = new ComboBox();
            this.lblHireDate = new Label();
            this.dtpHireDate = new DateTimePicker();
            this.lblSalary = new Label();
            this.txtSalary = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            int y = 20;
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new Point(20, y);
            this.lblFullName.Text = "Full Name:";
            this.txtFullName.Location = new Point(120, y - 3);
            this.txtFullName.Size = new Size(250, 23);

            y += 40;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(20, y);
            this.lblEmail.Text = "Email:";
            this.txtEmail.Location = new Point(120, y - 3);
            this.txtEmail.Size = new Size(250, 23);

            y += 40;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new Point(20, y);
            this.lblPhone.Text = "Phone:";
            this.txtPhone.Location = new Point(120, y - 3);
            this.txtPhone.Size = new Size(250, 23);

            y += 40;
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new Point(20, y);
            this.lblRole.Text = "Role:";
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new Point(120, y - 3);
            this.cmbRole.Size = new Size(250, 23);

            y += 40;
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Location = new Point(20, y);
            this.lblHireDate.Text = "Hire Date:";
            this.dtpHireDate.Location = new Point(120, y - 3);
            this.dtpHireDate.Size = new Size(250, 23);

            y += 40;
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new Point(20, y);
            this.lblSalary.Text = "Salary:";
            this.txtSalary.Location = new Point(120, y - 3);
            this.txtSalary.Size = new Size(250, 23);

            y += 40;
            this.btnSave.Location = new Point(120, y);
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += btnSave_Click;

            this.btnCancel.Location = new Point(230, y);
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += btnCancel_Click;

            this.ClientSize = new Size(400, y + 60);
            this.Controls.AddRange(new Control[] {
                lblFullName, txtFullName, lblEmail, txtEmail, lblPhone, txtPhone,
                lblRole, cmbRole, lblHireDate, dtpHireDate, lblSalary, txtSalary,
                btnSave, btnCancel
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = _isEditMode ? "Edit Employee" : "Add Employee";
        }
    }

    // Shift Management Form
    public partial class ShiftManagementForm : Form
    {
        private readonly EmployeeService _employeeService;

        public ShiftManagementForm()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            LoadShifts();
        }

        private void LoadShifts()
        {
            dgvShifts.DataSource = null;
            dgvShifts.DataSource = _employeeService.GetAllShifts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadShifts();
        }
    }

    partial class ShiftManagementForm
    {
        private DataGridView dgvShifts;
        private Panel panelButtons;
        private Button btnRefresh;

        private void InitializeComponent()
        {
            this.dgvShifts = new DataGridView();
            this.panelButtons = new Panel();
            this.btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).BeginInit();

            this.dgvShifts.AllowUserToAddRows = false;
            this.dgvShifts.AllowUserToDeleteRows = false;
            this.dgvShifts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShifts.Dock = DockStyle.Fill;
            this.dgvShifts.ReadOnly = true;
            this.dgvShifts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.panelButtons.Controls.Add(btnRefresh);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Size = new Size(800, 50);

            this.btnRefresh.Location = new Point(12, 10);
            this.btnRefresh.Size = new Size(100, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += btnRefresh_Click;

            this.ClientSize = new Size(800, 450);
            this.Controls.Add(dgvShifts);
            this.Controls.Add(panelButtons);
            this.Text = "Shift Management";

            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).EndInit();
        }
    }

    // User Management Form
    public partial class UserManagementForm : Form
    {
        private readonly AuthService _authService;

        public UserManagementForm(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            LoadUsers();
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _authService.GetAllUsers();
            
            if (dgvUsers.Columns.Contains("Password"))
            {
                dgvUsers.Columns["Password"]!.Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }

    partial class UserManagementForm
    {
        private DataGridView dgvUsers;
        private Panel panelButtons;
        private Button btnRefresh;

        private void InitializeComponent()
        {
            this.dgvUsers = new DataGridView();
            this.panelButtons = new Panel();
            this.btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();

            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.Dock = DockStyle.Fill;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.panelButtons.Controls.Add(btnRefresh);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Size = new Size(800, 50);

            this.btnRefresh.Location = new Point(12, 10);
            this.btnRefresh.Size = new Size(100, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += btnRefresh_Click;

            this.ClientSize = new Size(800, 450);
            this.Controls.Add(dgvUsers);
            this.Controls.Add(panelButtons);
            this.Text = "User Management";

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
        }
    }
}
