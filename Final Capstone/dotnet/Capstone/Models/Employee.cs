using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public List<int> LandlordIds { get; set; }
    }
}
