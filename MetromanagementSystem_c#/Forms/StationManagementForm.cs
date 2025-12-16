using metrosistemi.Data;
using metrosistemi.Models;
using metrosistemi.Services;

namespace metrosistemi.Forms
{
    public partial class StationManagementForm : Form
    {
        private readonly StationService _stationService;
        private readonly DataStore _dataStore;

        public StationManagementForm()
        {
            InitializeComponent();
            _stationService = new StationService();
            _dataStore = DataStore.Instance;
            LoadStations();
        }

        private void LoadStations()
        {
            var stations = _stationService.GetAllStations();
            dgvStations.DataSource = null;
            dgvStations.DataSource = stations;
            
            // Configure columns
            if (dgvStations.Columns.Count > 0)
            {
                dgvStations.Columns["Id"].HeaderText = "ID";
                dgvStations.Columns["Name"].HeaderText = "Station Name";
                dgvStations.Columns["Address"].HeaderText = "Address";
                dgvStations.Columns["Latitude"].HeaderText = "Latitude";
                dgvStations.Columns["Longitude"].HeaderText = "Longitude";
                dgvStations.Columns["LineId"].HeaderText = "Line ID";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new StationEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadStations();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStations.SelectedRows.Count > 0)
            {
                var station = (Station)dgvStations.SelectedRows[0].DataBoundItem;
                var form = new StationEditForm(station);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadStations();
                }
            }
            else
            {
                MessageBox.Show("Please select a station to edit.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStations.SelectedRows.Count > 0)
            {
                var station = (Station)dgvStations.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Are you sure you want to delete station '{station.Name}'?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    _stationService.DeleteStation(station.Id);
                    LoadStations();
                    MessageBox.Show("Station deleted successfully.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a station to delete.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStations();
        }
    }
}
