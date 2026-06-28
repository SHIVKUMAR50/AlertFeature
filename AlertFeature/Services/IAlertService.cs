using Domain;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAlertService
    {
        public Task<Users[]> GetAllUsers();
        public Task<List<AlertResponse>> GetAlertInfo(string userEmail);

    }
}
