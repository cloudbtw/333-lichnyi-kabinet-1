using UrmetJournal.Models;

namespace UrmetJournal.Services
{
    public interface IJournalService
    {
        Group GetGroup(int groupId);
        IEnumerable<Lesson> GetLessons(int groupId, string dayOfWeek);
        Lesson GetLesson(int lessonId);
        Lesson AddLesson(Lesson lesson);
        Lesson UpdateLesson(Lesson lesson);
        void DeleteLesson(int lessonId);
        SpecialInfo GetSpecialInfo(int groupId);
        SpecialInfo UpdateSpecialInfo(SpecialInfo info);
    }
}