namespace Infrastructure.Entities
{
    public class MaintenanceInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AlertId { get; set; }
        public AlertInfo? AlertInfo { get; set; }
    }
}
