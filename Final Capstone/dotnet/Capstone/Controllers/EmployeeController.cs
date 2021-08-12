using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDao employeeDao;
        public EmployeeController(IEmployeeDao _employeeDao)
        {
            employeeDao = _employeeDao;
        }

        [HttpGet("{id}/employees")]
        public ActionResult<List<Employee>> GetEmployees(int id)
        {
            List<Employee> employees = employeeDao.GetEmployeesByLandlordId(id);

            if (employees.Count != 0)
            {
                return Ok(employees);
            }
            else
            {
                return BadRequest(new { message = "No employees found" });
            }
        }

        [HttpGet("{id}/employee/{employeeId}")]
        public ActionResult<Employee> GetEmployee(int employeeId)
        {
            Employee employee = employeeDao.GetEmployee(employeeId);

            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return BadRequest(new { message = "Employee not found" });
            }
        }

        [HttpPost("{id}/newemployee")]
        public ActionResult<int> AddEmployee(int id, Employee employee)
        {
            int successStatus = employeeDao.AddEmployee(id, employee);

            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Employee not successfully added." });
            }
        }
        [HttpDelete("{id}/employee/{employeeId}")]
        public IActionResult DeleteEmployee(int id, int employeeId)
        {
            int successStatus = 0;

            successStatus = employeeDao.DeleteEmployee(id, employeeId);

            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Employee not successfully deleted." });
            }
        }
    }
}
