using Service.Helper;
using Service.Services;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Group = Domain.Models.Group;

namespace CourseApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupService groupService = new();
            Console.WriteLine("Choose an option:");
            ConsoleHelper.MsgColor(ConsoleColor.Cyan, "1- Create Group, 2- Update a Group Info, 3- Get a Group By ID, 4- Get All Groups, 5- Delete Group");

            while (true)
            {
            Input:
                Console.Write("Enter a number: ");
                string? input = Console.ReadLine();
                int number;

                bool isNumber = int.TryParse(input, out number);

                if (isNumber)
                {
                    if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[1-5]$"))
                    {
                        switch (number)
                        {
                            case 1:
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

                                break;
                            case 2:
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
                                break;
                            case 3:
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
                                break;
                            case 4:
                                Group[] groups = groupService.GetAllGroup().ToArray();
                                foreach (var group in groups)
                                {
                                    ConsoleHelper.MsgColor(ConsoleColor.Green, $"Group Info - Group ID: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                                }
                                break;
                            case 5:

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
                                break;
                            default:
                                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid option. Please choose a number between 1 and 5. Pay attention to white spaces and symbols");
                                goto Input;
                        }
                    }
                    else
                    {
                        ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid option. Please choose a number between 1 and 5.");
                        goto Input;
                    }
                }
                else
                {
                    ConsoleHelper.MsgColor(ConsoleColor.Red, "Please enter a valid number (1–5).");
                    goto Input;
                }
            }
        }
    }
}
