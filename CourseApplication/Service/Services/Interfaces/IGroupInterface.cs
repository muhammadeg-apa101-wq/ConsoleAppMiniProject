using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupInterface
    {
        Group CreateGroup(Group group);
        Group UpdateGroup(int id, Group group);
        Group GetGroupById(int id);
        List<Group> GetAllGroup(Predicate<Group>? predicate = null);
        List<Group> GetGroupByTeach(Predicate<Group>? predicate = null);
        List<Group> GetGroupByRoom(Predicate<Group>? predicate = null);
        List<Group> GetGroupByName(Predicate<Group>? predicate = null);
        void DeleteGroup(int id);
    }
}
