using Domain.Models;
using Service.Helper;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApplication.Controllers
{

    public class GroupController
    {
        GroupService groupService = new();

        public void Create()
        {
            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter group name: ");
            string? name = Console.ReadLine();

            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter teacher name: ");
            string? teacher = Console.ReadLine();

            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter room number: ");
        RoomInput: string? roomInput = Console.ReadLine();

            // eger room number duzgun daxil edilmeyibse RoomInput-e qayidacaq
            if (!int.TryParse(roomInput, out int room))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid room number. Try again.");
                goto RoomInput;
            }

            Group newGroup = new()
            {
                Name = name,
                Teacher = teacher,
                Room = room
            };

            Group createdGroup = groupService.CreateGroup(newGroup);

            if (createdGroup != null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Cyan, $"Group Info - Group ID: {createdGroup.Id}, Name: {createdGroup.Name}, Teacher: {createdGroup.Teacher}, Room: {createdGroup.Room}");
            }
            else
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Group creation failed. Please try again.");
            }

        }

        public void UpdateById()
        {
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Enter the group ID to update:");
        UpdateIdInput: string? updateIdInput = Console.ReadLine();
            if (int.TryParse(updateIdInput, out int updateId))
            {
                Group existingGroup = groupService.GetGroupById(updateId);
                if (existingGroup == null)
                {
                    ConsoleHelper.MsgColor(ConsoleColor.Red, $"Group with ID {updateId} not found.");
                    goto UpdateIdInput;
                }
            }
            else
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid ID. Only numbers are allowed.");
                goto UpdateIdInput;
            }
            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter group name: ");
            string? newName = Console.ReadLine();

            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter teacher name: ");
            string? newTeacher = Console.ReadLine();

            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter room number: ");
        NewRoomInput: string? newRoomInput = Console.ReadLine();

            // eger room number duzgun daxil edilmeyibse RoomInput-e qayidacaq
            if (!int.TryParse(newRoomInput, out int newRoom))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid room number. Try again.");
                goto NewRoomInput;
            }

            Group updatedGroup = new()
            {
                Name = newName,
                Teacher = newTeacher,
                Room = newRoom
            };
            groupService.DeleteGroup(updateId);
            groupService.CreateGroup(updatedGroup);
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Group information updated successfully.");
        }

        public void GetGroupById()
        {
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Enter the group ID:");
        GetByIdInput: string? groupIdInput = Console.ReadLine();
            if (int.TryParse(groupIdInput, out int groupId))
            {
                Group existingGroup = groupService.GetGroupById(groupId);
                if (existingGroup == null)
                {
                    ConsoleHelper.MsgColor(ConsoleColor.Red, $"Group with ID {groupId} not found.");
                    goto GetByIdInput;
                }

                ConsoleHelper.MsgColor(ConsoleColor.Cyan, $"Group Info - Group ID: {existingGroup.Id}, Name: {existingGroup.Name}, Teacher: {existingGroup.Teacher}, Room: {existingGroup.Room}");
            }
            else
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid ID. Only numbers are allowed.");
                goto GetByIdInput;
            }
        }

        public void GetAllGroups()
        {
            //butun group-lari getirir ve arraya salir
            Group[] groups = groupService.GetAllGroup().ToArray();
            foreach (var group in groups)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Green, $"Group Info - Group ID: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
            }
        }

        public void DeleteGroupById()
        {
        //group silir
        DeleteInput: Console.Write("Enter the Group ID to delete: ");
            string? deleteInput = Console.ReadLine();
            if (int.TryParse(deleteInput, out int deleteId))
            {
                groupService.DeleteGroup(deleteId);
            }
            else
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid ID. Only numbers are allowed.");
                goto DeleteInput;
            }
        }

        public void GetGroupsByTeacher() 
        {
            //mellime gore group-lari getirir
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Enter the teacher name:");
            string? teacherName = Console.ReadLine();
            Group[] groupsByTeacher = groupService.GetGroupByTeach(g => g.Teacher != null && g.Teacher.Equals(teacherName, StringComparison.OrdinalIgnoreCase)).ToArray();
            foreach (var group in groupsByTeacher)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Green, $"Group Info - Group ID: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
            }
        }

        public void GetGroupsByRoom() 
        {
            //room-a gore group-lari getirir
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Enter the room number:");
        RoomNumberInput: string? roomNumberInput = Console.ReadLine();
            if (int.TryParse(roomNumberInput, out int roomNumber))
            {
                Group[] groupsByRoom = groupService.GetGroupByRoom(g => g.Room == roomNumber).ToArray();
                foreach (var group in groupsByRoom)
                {
                    ConsoleHelper.MsgColor(ConsoleColor.Green, $"Group Info - Group ID: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                }
            }
            else
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid room number. Try again.");
                goto RoomNumberInput;
            }
        }

        public void GetGroupsByName() 
        {
            //groupun adina gore group-lari getirir
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Enter a group name:");
            string? groupName = Console.ReadLine()?.Trim();
            Group[] groupsByName = groupService.GetGroupByName(g => g.Name != null && g.Name.Equals(groupName, StringComparison.OrdinalIgnoreCase)).ToArray();
            foreach (var group in groupsByName)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Green, $"Group Info - Group ID: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
            }
        }

    }
}
