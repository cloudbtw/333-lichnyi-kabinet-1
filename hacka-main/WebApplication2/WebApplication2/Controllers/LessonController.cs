using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UrmetJournal.Hubs;
using UrmetJournal.Models;
using UrmetJournal.Services;

namespace UrmetJournal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LessonController : ControllerBase
    {
        private readonly IJournalService _journalService;
        private readonly IHubContext<ScheduleHub> _hubContext;

        public LessonController(IJournalService journalService, IHubContext<ScheduleHub> hubContext)
        {
            _journalService = journalService;
            _hubContext = hubContext;
        }

        [HttpPost]
        [Authorize(Roles = "teacher,admin")]
        public async Task<IActionResult> AddLesson([FromBody] Lesson lesson)
        {
            var addedLesson = _journalService.AddLesson(lesson);

            await _hubContext.Clients.Group($"group-{lesson.GroupId}")
                .SendAsync("ReceiveScheduleUpdate", lesson.DayOfWeek);

            return Ok(addedLesson);
        }

        [HttpPut]
        [Authorize(Roles = "teacher,admin")]
        public async Task<IActionResult> UpdateLesson([FromBody] Lesson lesson)
        {
            var updatedLesson = _journalService.UpdateLesson(lesson);

            await _hubContext.Clients.Group($"group-{lesson.GroupId}")
                .SendAsync("ReceiveScheduleUpdate", lesson.DayOfWeek);

            return Ok(updatedLesson);
        }

        [HttpDelete("{lessonId}")]
        [Authorize(Roles = "teacher,admin")]
        public async Task<IActionResult> DeleteLesson(int lessonId)
        {
            var lesson = _journalService.GetLesson(lessonId);
            _journalService.DeleteLesson(lessonId);

            await _hubContext.Clients.Group($"group-{lesson.GroupId}")
                .SendAsync("ReceiveScheduleUpdate", lesson.DayOfWeek);

            return NoContent();
        }

        [HttpGet("{groupId}/{dayOfWeek}")]
        public IActionResult GetLessons(int groupId, string dayOfWeek)
        {
            var lessons = _journalService.GetLessons(groupId, dayOfWeek);
            return Ok(lessons);
        }
    }
}