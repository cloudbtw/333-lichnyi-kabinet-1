using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrmetJournal.Models;
using UrmetJournal.Services;

namespace UrmetJournal.Controllers
{
    [Authorize(Roles = "teacher,admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IJournalService _journalService;

        public TeacherController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpPost("lesson")]
        public IActionResult AddLesson([FromBody] Lesson lesson)
        {
            lesson.GroupId = int.Parse(User.FindFirst("GroupId").Value);
            var addedLesson = _journalService.AddLesson(lesson);
            return Ok(addedLesson);
        }

        [HttpPut("lesson")]
        public IActionResult UpdateLesson([FromBody] Lesson lesson)
        {
            var updatedLesson = _journalService.UpdateLesson(lesson);
            if (updatedLesson == null)
                return NotFound();
            return Ok(updatedLesson);
        }

        [HttpDelete("lesson/{lessonId}")]
        public IActionResult DeleteLesson(int lessonId)
        {
            _journalService.DeleteLesson(lessonId);
            return NoContent();
        }

        [HttpPut("specialinfo")]
        public IActionResult UpdateSpecialInfo([FromBody] SpecialInfo info)
        {
            info.GroupId = int.Parse(User.FindFirst("GroupId").Value);
            var updatedInfo = _journalService.UpdateSpecialInfo(info);
            return Ok(updatedInfo);
        }
    }
}