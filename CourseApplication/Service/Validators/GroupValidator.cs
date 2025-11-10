using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Service.Helper;
using Domain.Models;
using Group = Domain.Models.Group;

namespace Service.Validators
{
    public static class GroupValidator
    {
        public static bool Validate(Group group)
        {
            if (group is null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Group is null.");
                return false;
            }

            // sadece herfler ve bosluq ola biler
            if (string.IsNullOrWhiteSpace(group.Name) || !Regex.IsMatch(group.Name, @"^[A-Za-z ]+$"))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Group name can only contain letters and spaces!");
                return false;
            }

            // sadece reqem ola biler ve musbet olmalidir
            if (group.Room <= 0)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Room number must be a positive integer!");
                return false;
            }

            //sadece herfler ve bosluq ola biler
            if (string.IsNullOrWhiteSpace(group.Teacher) || !Regex.IsMatch(group.Teacher, @"^[A-Za-z ]+$"))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Teacher name can only contain letters and spaces!");
                return false;
            }

            return true;
        }
    }
}
