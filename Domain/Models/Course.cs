namespace Domain.Models;

public class Course
{
    public int id { get; set; }
    public required string coursename { get; set; }
    public string teacher { get; set; }
    public decimal price { get; set; }
}