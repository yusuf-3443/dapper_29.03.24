namespace Domain.Models;

public class Group
{
    public int id { get; set; }
    public required string groupname { get; set; }
    public int lerners { get; set; }
    public int courseid { get; set; }
}