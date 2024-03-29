using Domain.Models;

namespace Infrastructure.Services;

public interface IMentorService
{
    List<Mentor> GetCourses();
    Mentor GetMentorById(int id);
    string AddMentor(Mentor mentor);
    string UpdateMentor(Mentor mentor);
    string DeleteMentor(int id);
}