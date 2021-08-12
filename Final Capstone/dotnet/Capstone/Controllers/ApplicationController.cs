using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationDao appDao;
        public ApplicationController(IApplicationDao _appDao)
        {
            appDao = _appDao;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Application>> GetApplications(int id)
        {
            List<Application> app = appDao.GetApplications(id);

            if (app.Count != 0)
            {
                return Ok(app);
            }
            else
            {
                return BadRequest(new { message = "No application associated with that id." });
            }
        }

        [HttpPost]
        public ActionResult<int> AddApplication(Application app)
        {
            int appId = appDao.AddApplication(app);

            if (appId != 0)
            {
                return Ok(appId);
            }
            else
            {
                return BadRequest(new { message = "Application not successfully created." });
            }
        }

        [HttpPut("{id}/approve")]
        public ActionResult ApproveApplication(Application app, int id)
        {
            int successStatus = 0;

            if (app.ApplicationId == id)
            {
                successStatus = appDao.ApproveApplication(app);
            }
            if (successStatus == 3)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Application not successfully updated." });
            }
        }

        [HttpPut("{id}/reject")]
        public ActionResult RejectApplication(int id)
        {
            int successStatus = 0;

            successStatus = appDao.RejectApplication(id);

            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Application not successfully updated." });
            }
        }
    }
}
