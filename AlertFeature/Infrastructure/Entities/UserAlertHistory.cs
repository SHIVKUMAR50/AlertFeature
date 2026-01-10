namespace Infrastructure.Entities
{
    public class UserAlertHistory
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime LastSeenDate { get; set; }
        public int AlertId { get; set; }
        public AlertInfo AlertInfo { get; set; }
    }
}
