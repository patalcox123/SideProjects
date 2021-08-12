using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IApplicationDao
    {
        List<Application> GetApplications(int landlordId);
        int AddApplication(Application app);
        int ApproveApplication(Application app);
        int RejectApplication(int id);
    }
}
