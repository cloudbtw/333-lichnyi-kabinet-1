using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrmetJournal.Services;

namespace UrmetJournal.Controllers
{
    [Authorize(Roles = "student,teacher,admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IJournalService _journalService;

        public StudentController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpGet("group")]
        public IActionResult GetGroupInfo()
        {
            var groupId = int.Parse(User.FindFirst("GroupId").Value);
            var group = _journalService.GetGroup(groupId);
            return Ok(group);
        }

        [HttpGet("schedule/{dayOfWeek}")]
        public IActionResult GetSchedule(string dayOfWeek)
        {
            var groupId = int.Parse(User.FindFirst("GroupId").Value);
            var lessons = _journalService.GetLessons(groupId, dayOfWeek);
            return Ok(lessons);
        }

        [HttpGet("specialinfo")]
        public IActionResult GetSpecialInfo()
        {
            var groupId = int.Parse(User.FindFirst("GroupId").Value);
            var info = _journalService.GetSpecialInfo(groupId);
            return Ok(info);
        }
    }
}