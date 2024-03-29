using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class StudentService: IStudentService
{
    private readonly DapperContext _context;
    public StudentService()
    {
        _context= new DapperContext();
    }
    public List<Student> GetStudents()
    {
        var sql = "select * from students";
        var result = _context.Connection().Query<Student>(sql).ToList();
        return result;
    }

    public Student GetStudentById(int id)
    {
        var sql = "select * from students where id={@id}";
        var result = _context.Connection().QueryFirstOrDefault<Student>(sql);
        return result;
    }

    public string AddStudent(Student student)
    {
        var sql =  $"insert into students (fullname,age,phone)" +
                   $"values ('{student.fullname}',{student.age},'{student.phone}')";
        var inserted =  _context.Connection().Execute(sql);
        if (inserted > 0) return "Successfully created new student";
        return "Error in creating new student";
        
    }

    public string UpdateStudent(Student student)
    {
        var sql=$"update students set fullname = '{student.fullname}', "+
                $"age = {student.age},phone= '{student.phone}' "+
                $"where id = {student.id}";
        var inserted =  _context.Connection().Execute(sql);
        if (inserted > 0) return "Successfully updated student";
        return "Error in updating student";
    }

    public bool DeleteStudent(int id)
    {
        var sql = $"delete from students where id = {id}";
        var deleted =_context.Connection().Execute(sql);
        if (deleted > 0) return true;
        return false;
    }
}