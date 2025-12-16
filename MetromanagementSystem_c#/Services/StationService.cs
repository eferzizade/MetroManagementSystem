using metrosistemi.Data;
using metrosistemi.Models;

namespace metrosistemi.Services
{
    /// <summary>
    /// Service for managing stations
    /// </summary>
    public class StationService
    {
        private readonly DataStore _dataStore;

        public StationService()
        {
            _dataStore = DataStore.Instance;
        }

        /// <summary>
        /// Get all stations
        /// </summary>
        public List<Station> GetAllStations()
        {
            return _dataStore.Stations;
        }

        /// <summary>
        /// Get stations by line
        /// </summary>
        public List<Station> GetStationsByLine(int lineId)
        {
            return _dataStore.Stations.Where(s => s.LineId == lineId).ToList();
        }

        /// <summary>
        /// Get station by ID
        /// </summary>
        public Station? GetStationById(int id)
        {
            return _dataStore.Stations.FirstOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Add a new station
        /// </summary>
        public void AddStation(Station station)
        {
            station.Id = _dataStore.GetNextStationId();
            _dataStore.Stations.Add(station);

            // Add to line's station list
            var line = _dataStore.Lines.FirstOrDefault(l => l.Id == station.LineId);
            if (line != null && !line.StationIds.Contains(station.Id))
            {
                line.StationIds.Add(station.Id);
            }
        }

        /// <summary>
        /// Update station
        /// </summary>
        public void UpdateStation(Station station)
        {
            var existingStation = _dataStore.Stations.FirstOrDefault(s => s.Id == station.Id);
            if (existingStation != null)
            {
                // Remove from old line if line changed
                if (existingStation.LineId != station.LineId)
                {
                    var oldLine = _dataStore.Lines.FirstOrDefault(l => l.Id == existingStation.LineId);
                    if (oldLine != null)
                    {
                        oldLine.StationIds.Remove(station.Id);
                    }

                    // Add to new line
                    var newLine = _dataStore.Lines.FirstOrDefault(l => l.Id == station.LineId);
                    if (newLine != null && !newLine.StationIds.Contains(station.Id))
                    {
                        newLine.StationIds.Add(station.Id);
                    }
                }

                existingStation.Name = station.Name;
                existingStation.Address = station.Address;
                existingStation.Latitude = station.Latitude;
                existingStation.Longitude = station.Longitude;
                existingStation.LineId = station.LineId;
            }
        }

        /// <summary>
        /// Delete station
        /// </summary>
        public void DeleteStation(int stationId)
        {
            var station = _dataStore.Stations.FirstOrDefault(s => s.Id == stationId);
            if (station != null)
            {
                // Remove from line
                var line = _dataStore.Lines.FirstOrDefault(l => l.Id == station.LineId);
                if (line != null)
                {
                    line.StationIds.Remove(stationId);
                }

                _dataStore.Stations.Remove(station);
            }
        }

        /// <summary>
        /// Search stations by name
        /// </summary>
        public List<Station> SearchStations(string searchTerm)
        {
            return _dataStore.Stations
                .Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
