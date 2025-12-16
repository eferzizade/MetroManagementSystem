using metrosistemi.Data;
using metrosistemi.Models;

namespace metrosistemi.Forms
{
    // Line Management Form
    public partial class LineManagementForm : Form
    {
        private DataStore _dataStore;

        public LineManagementForm()
        {
            InitializeComponent();
            _dataStore = DataStore.Instance;
            LoadLines();
        }

        private void LoadLines()
        {
            dgvLines.DataSource = null;
            dgvLines.DataSource = _dataStore.Lines;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new LineEditForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadLines();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLines.SelectedRows.Count > 0)
            {
                var line = (Line)dgvLines.SelectedRows[0].DataBoundItem;
                var form = new LineEditForm(line);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadLines();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLines.SelectedRows.Count > 0)
            {
                var line = (Line)dgvLines.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"Delete line '{line.Name}'?", "Confirm", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _dataStore.Lines.Remove(line);
                    LoadLines();
                }
            }
        }
    }

    partial class LineManagementForm
    {
        private DataGridView dgvLines;
        private Panel panelButtons;
        private Button btnAdd, btnEdit, btnDelete;

        private void InitializeComponent()
        {
            this.dgvLines = new DataGridView();
            this.panelButtons = new Panel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLines.Dock = DockStyle.Fill;
            this.dgvLines.ReadOnly = true;
            this.dgvLines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Size = new Size(800, 400);

            this.panelButtons.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete });
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Size = new Size(800, 50);

            this.btnAdd.Location = new Point(12, 10);
            this.btnAdd.Size = new Size(100, 30);
            this.btnAdd.Text = "Add Line";
            this.btnAdd.Click += btnAdd_Click;

            this.btnEdit.Location = new Point(120, 10);
            this.btnEdit.Size = new Size(100, 30);
            this.btnEdit.Text = "Edit Line";
            this.btnEdit.Click += btnEdit_Click;

            this.btnDelete.Location = new Point(228, 10);
            this.btnDelete.Size = new Size(100, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += btnDelete_Click;

            this.ClientSize = new Size(800, 450);
            this.Controls.Add(dgvLines);
            this.Controls.Add(panelButtons);
            this.Text = "Line Management";

            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }

    // Line Edit Form
    public partial class LineEditForm : Form
    {
        private Line? _line;
        private bool _isEditMode;

        public LineEditForm(Line? line = null)
        {
            InitializeComponent();
            _line = line;
            _isEditMode = line != null;
            if (_isEditMode && _line != null)
            {
                txtName.Text = _line.Name;
                txtColor.Text = _line.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter line name.");
                return;
            }

            var line = _line ?? new Line { Id = DataStore.Instance.GetNextLineId() };
            line.Name = txtName.Text.Trim();
            line.Color = txtColor.Text.Trim();

            if (!_isEditMode)
                DataStore.Instance.Lines.Add(line);

            MessageBox.Show("Line saved successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    partial class LineEditForm
    {
        private Label lblName, lblColor;
        private TextBox txtName, txtColor;
        private Button btnSave, btnCancel;

        private void InitializeComponent()
        {
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblColor = new Label();
            this.txtColor = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(20, 20);
            this.lblName.Text = "Line Name:";

            this.txtName.Location = new Point(120, 17);
            this.txtName.Size = new Size(250, 23);

            this.lblColor.AutoSize = true;
            this.lblColor.Location = new Point(20, 60);
            this.lblColor.Text = "Color (Hex):";

            this.txtColor.Location = new Point(120, 57);
            this.txtColor.Size = new Size(250, 23);
            this.txtColor.Text = "#000000";

            this.btnSave.Location = new Point(120, 100);
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += btnSave_Click;

            this.btnCancel.Location = new Point(230, 100);
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += btnCancel_Click;

            this.ClientSize = new Size(400, 160);
            this.Controls.AddRange(new Control[] { lblName, txtName, lblColor, txtColor, btnSave, btnCancel });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = _isEditMode ? "Edit Line" : "Add Line";
        }
    }
}
