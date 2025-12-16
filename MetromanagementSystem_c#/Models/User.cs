namespace metrosistemi.Models
{
    /// <summary>
    /// User roles for system access
    /// </summary>
    public enum UserRole
    {
        Admin,
        Operator
    }

    /// <summary>
    /// Represents a system user with login credentials
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            FullName = string.Empty;
            IsActive = true;
        }

        public override string ToString()
        {
            return $"{Username} ({Role})";
        }
    }
}
