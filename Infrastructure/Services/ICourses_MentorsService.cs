using Domain.Models;

namespace Infrastructure.Services;

public interface ICourses_MentorsService
{
    List<Courses_Mentors> GetCoursesMentors();
    Courses_Mentors GetCoursesMentorsById(int id);
    string AddCourses_Mentors(Courses_Mentors coursesMentors);
    string UpdateCourses_Mentors(Courses_Mentors coursesMentors);
    string DeleteCoursesMentors(int id);
}