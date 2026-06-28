using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AlertResponse
    {
        public string Email { get; set; }
        public AlertInfo AlertInformation { get; set; }
        public DateTime? LastSeenDate { get; set; }
        public AlertCategory Category { get; set; }
        public ReleaseInfo releaseInfo { get; set; }
        public MaintenanceInfo maintenanceInfo { get; set; }
    }
    public class AlertCategory
    {
        public string CategoryName { get; set; }
        public bool IsVisibleToNormalUsers { get; set; }
    }
    public class ReleaseInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
    public class MaintenanceInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class AlertInfo
    {
        public DateTime AlertStartDate { get; set; }
        public DateTime AlertEndDate { get; set; }
    }
}
