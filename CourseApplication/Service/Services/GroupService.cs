using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using Service.Validators;
using Service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupInterface
    {
        private readonly GroupRepository _groupRepository;
        public int count;

        public GroupService()
        {
            _groupRepository = new();
        }
        //group elave eden method
        public Group CreateGroup(Group group)
        {
            
            if (!GroupValidator.Validate(group))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Group information is invalid! Please check input values.");
                return null; // sehv varsa, null qaytarir
            }

            group.Id = ++count;
            _groupRepository.Create(group);

            ConsoleHelper.MsgColor(ConsoleColor.Green, "Group successfully created!");
            return group;
        }
        //group silen method
        public void DeleteGroup(int id)
        {
            Group group = _groupRepository.GetById(g => g.Id == id);

            if (group == null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, $"Group with ID {id} not found.");
                return;
            }

            _groupRepository.Delete(id);
            ConsoleHelper.MsgColor(ConsoleColor.Green, $"Group with ID {id} has been deleted.");

        }
        //butun group-lari getirir
        public List<Group> GetAllGroup(Predicate<Group>? predicate = null)
        {
            return _groupRepository.GetAll(predicate);
        }
        //id-ye gore group getirir
        public Group GetGroupById(int id)
        {
           Group group = _groupRepository.GetById(g => g.Id == id);
            if (group == null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, $"Group with ID {id} not found.");
                return null;
            }
            return group;
        }
        //group-u yenileyen method
        public Group UpdateGroup(int id, Group group)
        {
            if (!GroupValidator.Validate(group))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Group information is invalid! Please check input values.");
                return null;
            }

            group.Id = id;
            _groupRepository.Update(id, group);

            return group;
        }
    }
}
