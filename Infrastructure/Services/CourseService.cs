using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class CourseService : ICourseService
{
    private readonly DapperContext _context;
    public CourseService()
    {
        _context= new DapperContext();
    }
    public List<Course> GetCourses()
    {
        var sql = $"Select * from courses";
        var result = _context.Connection().Query<Course>(sql);
        return result.ToList();
    }

    public Course GetCourseById(int id)
    {
        var sql = $"Select * from courses where id = {@id}";
        var result = _context.Connection().QueryFirstOrDefault<Course>(sql);
        return result;
    }

    public string AddCourse(Course course)
    {
        var sql = $"Insert into courses(coursename,teacher,price)" +
                  $"values ('{course.coursename}','{course.teacher}',{course.price})";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Course successfully added";
        return "Failed to add result";
    }

    public string UpdateCourse(Course course)
    {
        var sql = $"Update courses" +
                  $"set coursename = '{course.coursename}',teacher = '{course.teacher}',price = '{course.price}' where id = {course.id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Course successfully updated";
        return "Failed to update course";
    }

    public string DeleteCourse(int id)
    {
        var sql = $"Delete * from courses where id = {id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Course successfully deleted";
        return "Failed to delete course";
    }
}