using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class Courses_MentorsService : ICourses_MentorsService
{
    private readonly DapperContext _context;
    public Courses_MentorsService()
    {
        _context= new DapperContext();
    }

    public List<Courses_Mentors> GetCoursesMentors()
    {
       var sql = $"Select * from courses_mentors";
       var result = _context.Connection().Query<Courses_Mentors>(sql);
       return result.ToList();
    }

    public Courses_Mentors GetCoursesMentorsById(int id)
    {
        var sql = $"Select * from courses_mentors where id = {@id}";
        var result = _context.Connection().QueryFirstOrDefault<Courses_Mentors>(sql);
        return result;
    }

    public string AddCourses_Mentors(Courses_Mentors coursesMentors)
    {
        var sql = $"Insert into courses_mentors(courseid,mentorid)" +
                  $"values ({coursesMentors.courseid},{coursesMentors.mentorid})";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Coursementor successfully added";
        return "Failed to add Coursementor";
    }

    public string UpdateCourses_Mentors(Courses_Mentors coursesMentors)
    {
        var sql = $"Update courses_mentors" +
                  $"set courseid = {coursesMentors.courseid},mentorid = {coursesMentors.mentorid}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Coursementor successfully added";
        return "Failed to update Coursementor";
    }

    public string DeleteCoursesMentors(int id)
    {
        var sql = $"Delete * from courses_mentors where id = {@id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Coursementor successfully deleted";
        return "Failed to delete Coursementor";
    }
}