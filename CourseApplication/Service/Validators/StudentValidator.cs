using System;
using System.Text.RegularExpressions;
using Service.Helper;
using Domain.Models;

namespace Service.Validators
{
    public static class StudentValidator
    {
        public static bool Validate(Student student)
        {
            if (student is null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Student is null.");
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(student.Name) || !Regex.IsMatch(student.Name, @"^[A-Za-z ]+$"))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Student name can only contain letters and spaces!");
                return false;
            }

          
            if (string.IsNullOrWhiteSpace(student.Surname) || !Regex.IsMatch(student.Surname, @"^[A-Za-z ]+$"))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Student surname can only contain letters and spaces!");
                return false;
            }

            
            if (student.Age <= 0 || student.Age > 120)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Age must be a positive integer (<= 120).");
                return false;
            }

            //hemin id-de groupun olub olmadigini yoxlayir
            if (student.group != null)
            {
                if (student.group.Id <= 0)
                {
                    ConsoleHelper.MsgColor(ConsoleColor.Red, "Assigned group must have a valid Id.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(student.group.Name) || !Regex.IsMatch(student.group.Name, @"^[A-Za-z ]+$"))
                {
                    ConsoleHelper.MsgColor(ConsoleColor.Red, "Assigned group name can only contain letters and spaces.");
                    return false;
                }
            }

            return true;
        }
    }
}