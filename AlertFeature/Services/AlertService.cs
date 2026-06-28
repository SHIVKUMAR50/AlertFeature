using Domain;
using Infrastructure;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Services
{
    public class AlertService(AlertDbContext alertDbContext) : IAlertService
    {
        public async Task<List<AlertResponse>> GetAlertInfo(string email)
        {

            var userAlerts = alertDbContext.UserAlertHistory.Where(x => x.Email == email).Select(x => x.AlertInfo).ToList();
            var allAlerts = alertDbContext.AlertInfo.ToList();
            var newAlerts = allAlerts.Except(userAlerts).ToList();
            if (newAlerts is not null)
            {
                List<Infrastructure.Entities.AlertInfo> alertInfos = [.. newAlerts];
                List<UserAlertHistory> alertsToBeAdded = [];
                foreach (var alertInfo in alertInfos)
                {
                    UserAlertHistory alert = new()
                    {
                        Email = email,
                        AlertId = alertInfo.Id,
                    };
                    alertsToBeAdded.Add(alert);
                }
                await alertDbContext.UserAlertHistory.AddRangeAsync(alertsToBeAdded);
                await alertDbContext.SaveChangesAsync();

            }
            var result = alertDbContext.UserAlertHistory.Include(x => x.AlertInfo).Include(x=>x.AlertInfo.ReleaseInfo).
                         Include(x=>x.AlertInfo.MaintenanceInfo).Where(x => x.Email == email).ToList();
            var finalResult = result.Select(x => new AlertResponse()
            {
                Email = x.Email,
                AlertInformation = new() {
                AlertStartDate=x.AlertInfo.AlertStartDate,
                AlertEndDate=x.AlertInfo.AlertEndDate,
                },
                releaseInfo = new()
                {
                    Title=x.AlertInfo?.ReleaseInfo?.Title,
                    Description=x.AlertInfo?.ReleaseInfo?.Description,
                    Version=x.AlertInfo?.ReleaseInfo?.Version
                },
                LastSeenDate = x.LastSeenDate
            }).ToList();
            return finalResult;
        }

        public async Task<Users[]> GetAllUsers()
        {
            throw new NotImplementedException();
        }

    }
}
