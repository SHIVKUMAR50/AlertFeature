namespace Infrastructure.Entities
{
    public class Users
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsAdminUser { get; set; } = false;
        public ICollection<UserAlertHistory> UserAlerts { get; set; }
    }
}
