using Domain.Models;
using Infrastructure.Services;

var mservice = new MentorService();

var mentor = new Mentor()
{
  fullname = "Saidmurod Davlatov",
  age = 25,
  subject = "history",
  experience = 5
};
// Console.WriteLine(mservice.AddMentor(mentor));

var cservice = new CourseService();
var course = new Course()
{
  id = 1,
  coursename  = "C#",
  teacher = "Toshmatov",
  price = 2000
};

var course1 = new Course()
{
  coursename  = "Javascript",
  teacher = "Said",
  price = 2500
};

// Console.WriteLine(cservice.AddCourse(course1));

// var result = cservice.GetCourseById(1);
// Console.WriteLine(result.coursename + result.teacher + result.price);

var sservice = new StudentService();
var student = new Student()
{
  fullname = "test",
  age = 15,
  phone = "4564545646"
};
var student1 = new Student()
{
  id = 1,
  fullname = "testov",
  age = 48,
  phone = "9999945646"
};
// Console.WriteLine(sservice.DeleteStudent(1));

var cmservice = new Courses_MentorsService();

var courses_mentors1 = new Courses_Mentors()
{
  courseid = 2,
  mentorid = 1
};

var courses_mentors2 = new Courses_Mentors()
{
  courseid = 2,
  mentorid = 3
};

var courses_mentors3 = new Courses_Mentors()
{
  courseid = 3,
  mentorid = 3
};

Console.WriteLine(cmservice.AddCourses_Mentors(courses_mentors1));

Console.WriteLine(cmservice.AddCourses_Mentors(courses_mentors2));

Console.WriteLine(cmservice.AddCourses_Mentors(courses_mentors3));