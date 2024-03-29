using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class GroupService:IGroupService
{
    private readonly DapperContext _context;
    public GroupService()
    {
        _context= new DapperContext();
    }
    public List<Group> GetGroups()
    {
        var sql = $"Select * from groups";
        var result = _context.Connection().Query<Group>(sql);
        return result.ToList();
    }

    public Group GetGroupById(int id)
    {
        var sql = $"Select * from groups where id = {@id}";
        var result = _context.Connection().QueryFirstOrDefault<Group>(sql);
        return result;
    }

    public string AddGroup(Group group)
    {
        var sql = $"Insert into groups(groupname,lerners,courseid)" +
                  $"values '{group.groupname}',{group.lerners},{group.courseid}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Group successfully added";
        return "Failed to add group";
    }

    public string UpdateGroup(Group group)
    {
        var sql = $"Update groups" +
                  $"set groupname = '{group.groupname}',lerners = {group.lerners},courseid = {group.courseid} where id = {group.id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Group successfully updated";
        return "Failed to update group";
    }

    public string DeleteGroup(int id)
    {
        var sql = $"Delete * from groups where id = {@id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return "Group successfully deleted";
        return "Failed to delete group";
    }
}