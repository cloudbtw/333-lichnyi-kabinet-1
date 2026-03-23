using UrmetJournal.Models;

namespace UrmetJournal.Services
{
    public class JournalService : IJournalService
    {
        private readonly List<Group> _groups = new()
        {
            new Group { Id = 1, Name = "П-41", MissedClasses = 3 }
        };

        private readonly List<Lesson> _lessons = new()
        {
            new Lesson { Id = 1, GroupId = 1, DayOfWeek = "monday", OrderNumber = 1,
                        Subject = "Математика", Teacher = "Иванова А.П.", Room = "205", Floor = 2 },
            new Lesson { Id = 2, GroupId = 1, DayOfWeek = "monday", OrderNumber = 2,
                        Subject = "Физика", Teacher = "Петров С.И.", Room = "104", Floor = 1 }
        };

        private readonly List<SpecialInfo> _specialInfos = new()
        {
            new SpecialInfo { Id = 1, GroupId = 1,
                            Information = "Завтра собрание в 15:00",
                            LastUpdated = DateTime.Now }
        };

        public Group GetGroup(int groupId)
        {
            return _groups.FirstOrDefault(g => g.Id == groupId);
        }

        public IEnumerable<Lesson> GetLessons(int groupId, string dayOfWeek)
        {
            return _lessons.Where(l => l.GroupId == groupId && l.DayOfWeek == dayOfWeek)
                          .OrderBy(l => l.OrderNumber);
        }

        public Lesson GetLesson(int lessonId)
        {
            return _lessons.FirstOrDefault(l => l.Id == lessonId);
        }

        public Lesson AddLesson(Lesson lesson)
        {
            lesson.Id = _lessons.Max(l => l.Id) + 1;
            _lessons.Add(lesson);
            return lesson;
        }

        public Lesson UpdateLesson(Lesson lesson)
        {
            var existingLesson = _lessons.FirstOrDefault(l => l.Id == lesson.Id);
            if (existingLesson != null)
            {
                existingLesson.Subject = lesson.Subject;
                existingLesson.Teacher = lesson.Teacher;
                existingLesson.Room = lesson.Room;
                existingLesson.Floor = lesson.Floor;
                existingLesson.DayOfWeek = lesson.DayOfWeek;
                existingLesson.OrderNumber = lesson.OrderNumber;
            }
            return existingLesson;
        }

        public void DeleteLesson(int lessonId)
        {
            var lesson = _lessons.FirstOrDefault(l => l.Id == lessonId);
            if (lesson != null)
            {
                _lessons.Remove(lesson);
            }
        }

        public SpecialInfo GetSpecialInfo(int groupId)
        {
            return _specialInfos.FirstOrDefault(s => s.GroupId == groupId);
        }

        public SpecialInfo UpdateSpecialInfo(SpecialInfo info)
        {
            var existingInfo = _specialInfos.FirstOrDefault(s => s.GroupId == info.GroupId);
            if (existingInfo != null)
            {
                existingInfo.Information = info.Information;
                existingInfo.LastUpdated = DateTime.Now;
            }
            else
            {
                info.Id = _specialInfos.Max(s => s.Id) + 1;
                info.LastUpdated = DateTime.Now;
                _specialInfos.Add(info);
                existingInfo = info;
            }
            return existingInfo;
        }
    }
}