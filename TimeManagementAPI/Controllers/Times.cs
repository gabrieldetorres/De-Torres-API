using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvertimeBl;
using Models;
using TimeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace TimeManagementAPI.Controllers
{
    [Route("api/Times")]
    [ApiController]
    public class Times : ControllerBase
    {
        private readonly OvertimeClass _appservice;

        public Times()
        {
            _appservice = new OvertimeClass();
        }

     
        [HttpGet]
        public ActionResult<IEnumerable<OvetimeClass3>> GetTime()
        {
            var time = _appservice.GetTime();
            return Ok(time);
        }

        [HttpPost]
        public IActionResult CreateTime([FromBody] TimeViewModel times)
        {
            if (times == null)
            {
                return BadRequest("Time is required.");
            }

            var newTime = new OvetimeClass3
            {
                Id = times.Id,
                Name = times.Name,
                TimeIn = times.TimeIn,
                Timeout = times.Timeout
            };

            _appservice.AddTime(newTime);

            return Ok(newTime);
        }

        //[HttpPatch("{id:guid}")]
        //public IActionResult UpdateTask(Guid id, [FromBody] TaskViewModel taskitem)
        //{
        //    if (taskitem == null)
        //    {
        //        return BadRequest("Task data is required.");
        //    }

        //    var existingTask = _appservice.GetTasks().FirstOrDefault(t => t.TaskId == id);

        //    if (existingTask == null)
        //    {
        //        return NotFound();
        //    }

        //    _appservice.EditTask(id, taskitem.TaskName);

        //    return NoContent();
        //}

        //[HttpDelete("{id:guid}")]
        //public IActionResult DeleteAccount(Guid id)
        //{
        //    var existingTasks = _appservice.GetTasks();

        //    if (existingTasks == null)
        //    {
        //        return NotFound();
        //    }

        //    _appservice.DeleteTask(id);

        //    return NoContent();
        //}
    }
}
