namespace Infrastructure.Entities
{
    public class Users
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; }
        public string Password { get; set; }
        public ICollection<UserAlertHistory> UserAlerts { get; set; }
    }
}
