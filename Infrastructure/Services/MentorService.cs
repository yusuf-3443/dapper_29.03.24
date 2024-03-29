using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class MentorService
{
    private readonly DapperContext _context;
    public MentorService()
    {
        _context= new DapperContext();
    }
    public List<Mentor> GetMentors()
    {
        var sql = $"Select * from mentors";
        var result = _context.Connection().Query<Mentor>(sql);
        return result.ToList();
    }

    public Mentor GetMentorById(int id)
    {
        var sql = $"Select * from mentors where id = {@id}";
        var result = _context.Connection().QueryFirstOrDefault<Mentor>(sql);
        return result;
    }

    public string AddMentor(Mentor mentor)
    {
        var sql = $"Insert into mentors(fullname,age,subject,experience)" +
                  $"values ('{mentor.fullname}',{mentor.age},'{mentor.subject}',{mentor.experience})";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Mentor successfully added";
        return "Failed to add mentor";
    }

    public string UpdateMentor(Mentor mentor)
    {
        var sql = $"Update mentors" +
                  $"set fullname = '{mentor.fullname}',age = {mentor.age},subject = '{mentor.subject}',experience = {mentor.experience} where id = {mentor.id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Mentor successfully updated";
        return "Failed to update mentor";
    }

    public string DeleteMentor(int id)
    {
        var sql = $"Delete * from mentors where id = {id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Mentor successfully deleted";
        return "Failed to delete mentor";
    }
}