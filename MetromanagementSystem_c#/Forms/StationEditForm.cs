using metrosistemi.Data;
using metrosistemi.Models;
using metrosistemi.Services;

namespace metrosistemi.Forms
{
    /// <summary>
    /// Form for adding/editing a station
    /// </summary>
    public partial class StationEditForm : Form
    {
        private readonly StationService _stationService;
        private readonly Station? _station;
        private readonly bool _isEditMode;

        public StationEditForm(Station? station = null)
        {
            InitializeComponent();
            _stationService = new StationService();
            _station = station;
            _isEditMode = station != null;

            LoadLines();
            if (_isEditMode && _station != null)
            {
                LoadStationData();
            }
        }

        private void LoadLines()
        {
            cmbLine.DataSource = DataStore.Instance.Lines;
            cmbLine.DisplayMember = "Name";
            cmbLine.ValueMember = "Id";
        }

        private void LoadStationData()
        {
            if (_station != null)
            {
                txtName.Text = _station.Name;
                txtAddress.Text = _station.Address;
                txtLatitude.Text = _station.Latitude.ToString();
                txtLongitude.Text = _station.Longitude.ToString();
                cmbLine.SelectedValue = _station.LineId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            var station = _station ?? new Station();
            station.Name = txtName.Text.Trim();
            station.Address = txtAddress.Text.Trim();
            station.Latitude = double.Parse(txtLatitude.Text);
            station.Longitude = double.Parse(txtLongitude.Text);
            station.LineId = (int)cmbLine.SelectedValue!;

            if (_isEditMode)
            {
                _stationService.UpdateStation(station);
                MessageBox.Show("Station updated successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _stationService.AddStation(station);
                MessageBox.Show("Station added successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter station name.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (!double.TryParse(txtLatitude.Text, out _))
            {
                MessageBox.Show("Please enter valid latitude.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLatitude.Focus();
                return false;
            }

            if (!double.TryParse(txtLongitude.Text, out _))
            {
                MessageBox.Show("Please enter valid longitude.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLongitude.Focus();
                return false;
            }

            if (cmbLine.SelectedValue == null)
            {
                MessageBox.Show("Please select a line.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLine.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    partial class StationEditForm
    {
        private Label lblName, lblAddress, lblLatitude, lblLongitude, lblLine;
        private TextBox txtName, txtAddress, txtLatitude, txtLongitude;
        private ComboBox cmbLine;
        private Button btnSave, btnCancel;

        private void InitializeComponent()
        {
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblAddress = new Label();
            this.txtAddress = new TextBox();
            this.lblLatitude = new Label();
            this.txtLatitude = new TextBox();
            this.lblLongitude = new Label();
            this.txtLongitude = new TextBox();
            this.lblLine = new Label();
            this.cmbLine = new ComboBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(20, 20);
            this.lblName.Text = "Station Name:";

            // txtName
            this.txtName.Location = new Point(120, 17);
            this.txtName.Size = new Size(250, 23);

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new Point(20, 60);
            this.lblAddress.Text = "Address:";

            // txtAddress
            this.txtAddress.Location = new Point(120, 57);
            this.txtAddress.Size = new Size(250, 23);

            // lblLatitude
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new Point(20, 100);
            this.lblLatitude.Text = "Latitude:";

            // txtLatitude
            this.txtLatitude.Location = new Point(120, 97);
            this.txtLatitude.Size = new Size(250, 23);

            // lblLongitude
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new Point(20, 140);
            this.lblLongitude.Text = "Longitude:";

            // txtLongitude
            this.txtLongitude.Location = new Point(120, 137);
            this.txtLongitude.Size = new Size(250, 23);

            // lblLine
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new Point(20, 180);
            this.lblLine.Text = "Line:";

            // cmbLine
            this.cmbLine.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLine.Location = new Point(120, 177);
            this.cmbLine.Size = new Size(250, 23);

            // btnSave
            this.btnSave.Location = new Point(120, 220);
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += btnSave_Click;

            // btnCancel
            this.btnCancel.Location = new Point(230, 220);
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += btnCancel_Click;

            // StationEditForm
            this.ClientSize = new Size(400, 280);
            this.Controls.AddRange(new Control[] {
                lblName, txtName, lblAddress, txtAddress,
                lblLatitude, txtLatitude, lblLongitude, txtLongitude,
                lblLine, cmbLine, btnSave, btnCancel
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = _isEditMode ? "Edit Station" : "Add Station";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
