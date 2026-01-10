namespace Infrastructure.Entities
{
    public class AlertInfo
    {
        public int Id { get; set; }
        public DateTime AlertStartDate { get; set; }
        public DateTime AlertEndDate { get; set; }
        public int AlertCategoryId { get; set; }
        public AlertCategory AlertCategory { get; set; }
        public ICollection<UserAlertHistory> AlertHistory { get; set; }
        public ReleaseInfo? ReleaseInfo { get; set; }
        public MaintenanceInfo? MaintenanceInfo { get; set; }
    }
}
