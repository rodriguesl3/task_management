using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Application;

namespace TaskManagement.ExternalService.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        private readonly IExternalTasksApplication _tasksApplication;

        public CheckController(IExternalTasksApplication tasksApplication)
        {
            _tasksApplication = tasksApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ValidationName()
        {
            return Ok("working fine!!!");
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> CheckNames(string name)
        {
            var response = await _tasksApplication.IsUniqueName(name);

            return Ok(new { isUnique = response });
        }
    }
}