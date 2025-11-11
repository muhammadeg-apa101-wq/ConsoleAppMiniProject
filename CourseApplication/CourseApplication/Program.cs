using CourseApplication.Controllers;
using Service.Enums;
using Service.Helper;
using Service.Services;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Group = Domain.Models.Group;

namespace CourseApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetMenu();
            GroupController groupController = new();
            StudentController studentController = new();


            while (true)
            {
            Input:
                Console.Write("Enter a number: ");
                string? input = Console.ReadLine();
                int number;

                bool isNumber = int.TryParse(input, out number);

                if (isNumber)
                {
                    if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^(?:[1-9]|1[0-3])$"))
                    {
                        switch (number)
                        {
                            case (int)GroupEnum.Create:
                                groupController.Create();
                                break;
                            case (int)GroupEnum.UpdateById:
                                groupController.UpdateById();
                                break;
                            case (int)GroupEnum.GetById:
                                groupController.GetGroupById();
                                break;
                            case (int)GroupEnum.GetAll:
                                groupController.GetAllGroups();
                                break;
                            case (int)GroupEnum.GetAllByName:
                                groupController.GetGroupsByName();
                                break;
                                case (int)GroupEnum.GetAllByTeacher:
                                groupController.GetGroupsByTeacher();
                                break;
                                case (int)GroupEnum.GetAllByRoom:
                                groupController.GetGroupsByRoom();
                                break;
                                case (int)GroupEnum.DeleteById:
                                groupController.DeleteGroupById();
                                break;
                                case (int)StudentEnum.Create:
                                studentController.CreateStudent();
                                break;
                            case (int)StudentEnum.Update:
                                studentController.UpdateStudent();
                                break;
                                case (int)StudentEnum.GetAllStudents:
                                    studentController.GetAllStudents();
                                    break;
                                case (int)StudentEnum.GetStudentById:
                                studentController.GetStudentById();
                                break;
                                case (int)StudentEnum.Delete:
                                    studentController.DeleteStudentById();
                                    break;
                            default:
                                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid option. Please choose a number between 1 and 9. Pay attention to white spaces and symbols");
                                goto Input;
                        }
                    }
                    else
                    {
                        ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid option. Please choose a number between 1 and 9.");
                        goto Input;
                    }
                }
                else
                {
                    ConsoleHelper.MsgColor(ConsoleColor.Red, "Please enter a valid number (1–13).");
                    goto Input;
                }

           
            }
        }
        public static void GetMenu() 
        {
            Console.WriteLine("Choose an option:");
            ConsoleHelper.MsgColor(ConsoleColor.Cyan, "Group : 1- Create Group, 2- Update a Group Info, 3- Get a Group By ID, 4- Get All Groups, 5- Get Groups by Name 6- Get Groups by Teacher 7 - Get Groups by Room, 8- Delete a Group By ID, Student: 9- Create a Student , 10- Update Student info, 11-GetAllStudents 12-Get Student by ID 13- Delete a Student");
        }
    }
}
