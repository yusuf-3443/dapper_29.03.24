using Domain.Models;

namespace Infrastructure.Services;

public interface IGroupService
{
    List<Group> GetGroups();
    Group GetGroupById(int id);
    string AddGroup(Group group);
    string UpdateGroup(Group group);
    string DeleteGroup(int id);
}