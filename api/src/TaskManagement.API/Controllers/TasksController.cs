using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagement.Domain.Application;
using TaskManagement.Domain.Validations;
using System.Linq;

namespace TaskManagement.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ITasksApplication _taskApp;

        public TasksController(ITasksApplication taskApp)
        {
            _taskApp = taskApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var foo = await _taskApp.GetAllTasks();

            return Ok(foo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var response = await _taskApp.GetTaskById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Domain.Entities.Task task)
        {
            var validation = task.CheckTaskInformation();

            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage));

            var wasCreated = await _taskApp.InsertTasks(task);
            if (wasCreated.Key)
                return Ok();

            return StatusCode(400, new { data = wasCreated.Value });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Domain.Entities.Task task)
        {
            var validation = task.CheckTaskInformation();

            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage));

            if (task.Id == 0)
                task.Id = id;

            var response = await _taskApp.UpdateTask(task);
            if (response.Key)
                return Ok();

            return StatusCode(400, new { data = response.Value });
        }

        [HttpGet]
        [Route("times")]
        public async Task<IActionResult> GetCreateUpdateTimes()
        {
            var result = await _taskApp.GetCreateUpdateTimes();
            return Ok(result);
        }

    }
}