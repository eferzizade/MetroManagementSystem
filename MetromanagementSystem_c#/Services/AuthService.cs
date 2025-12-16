using metrosistemi.Data;
using metrosistemi.Models;

namespace metrosistemi.Services
{
    /// <summary>
    /// Service for authentication and user management
    /// </summary>
    public class AuthService
    {
        private readonly DataStore _dataStore;
        private User? _currentUser;

        public AuthService()
        {
            _dataStore = DataStore.Instance;
        }

        /// <summary>
        /// Gets the currently logged-in user
        /// </summary>
        public User? CurrentUser => _currentUser;

        /// <summary>
        /// Authenticate a user
        /// </summary>
        public bool Login(string username, string password)
        {
            var user = _dataStore.Users.FirstOrDefault(u => 
                u.Username == username && 
                u.Password == password && 
                u.IsActive);

            if (user != null)
            {
                _currentUser = user;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Logout current user
        /// </summary>
        public void Logout()
        {
            _currentUser = null;
        }

        /// <summary>
        /// Check if current user is admin
        /// </summary>
        public bool IsAdmin()
        {
            return _currentUser?.Role == UserRole.Admin;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        public List<User> GetAllUsers()
        {
            return _dataStore.Users;
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        public void AddUser(User user)
        {
            user.Id = _dataStore.GetNextUserId();
            _dataStore.Users.Add(user);
        }

        /// <summary>
        /// Update user
        /// </summary>
        public void UpdateUser(User user)
        {
            var existingUser = _dataStore.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
                existingUser.FullName = user.FullName;
                existingUser.IsActive = user.IsActive;
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        public void DeleteUser(int userId)
        {
            var user = _dataStore.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _dataStore.Users.Remove(user);
            }
        }
    }
}
