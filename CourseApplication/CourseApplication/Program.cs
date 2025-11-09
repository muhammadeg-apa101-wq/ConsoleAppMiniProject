using Service.Helper;
using System.Runtime.CompilerServices;

namespace CourseApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Helper.MsgColor(ConsoleColor.Cyan, "1- Create Group, 2- Update a Group Info, 3- Get a Group By ID, 4- Get All Groups 5 - Delete Group");

            while (true) 
            {
            Input: string input = Console.ReadLine();
                int number;

             bool isNumber = int.TryParse(input, out number);

                if (isNumber)
                {
                    switch (number) 
                    {
                        case 1:
                            Helper.MsgColor(ConsoleColor.Green, "Creating a group...");
                            break;
                        case 2:
                            Helper.MsgColor(ConsoleColor.Green, "Updating group info...");
                            break;
                        case 3:
                            Helper.MsgColor(ConsoleColor.Green, "Getting group by ID...");
                            break;
                        case 4:
                            Helper.MsgColor(ConsoleColor.Green, "Getting all groups...");
                            break;
                        case 5:
                            Helper.MsgColor(ConsoleColor.Green, "Deleting a group...");
                            break;
                        default:
                            Helper.MsgColor(ConsoleColor.Red, "Invalid option. Please choose a number between 1 and 5.");
                            break;
                    }
                }
                else 
                {
                Helper.MsgColor(ConsoleColor.Red, "Please enter a number.");
                    goto Input;
                }
            }
        }
    }
}
