using System;
using System.Collections.Generic;
using System.Linq;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IEmployeeDao
    {
        List<Employee> GetEmployeesByLandlordId(int id);

        Employee GetEmployee(int id);

        int AddEmployee(int id, Employee employee);

        int DeleteEmployee(int landlordId, int employeeId);


    }
}
