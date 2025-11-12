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
    public class StudentController
    {
        StudentService studentService = new();

        public void CreateStudent()
        {
            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter student name: ");
            string? name = Console.ReadLine()?.Trim();

            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter student surname: ");
            string? surname = Console.ReadLine()?.Trim();

            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter student age: ");
        AgeInput: string? age = Console.ReadLine();
            // eger age duzgun daxil edilmeyibse AgeInput-e qayidacaq
            if (!int.TryParse(age?.Trim(), out int result))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid age. Try again.");
                goto AgeInput;
            }

            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter group Id (room): ");
        groupIdInput: string? groupId = Console.ReadLine();
            // eger group id duzgun daxil edilmeyibse groupIdInput-e qayidacaq
            if (!int.TryParse(groupId?.Trim(), out int groupIdValue))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid group id. Try again.");
                goto groupIdInput;
            }

            Student newStudent = new()
            {
                Name = name,
                Surname = surname,
                Age = result,
                group = new Group { Id = groupIdValue }
            };

            var createdStudent = studentService.CreateStudent(newStudent);

            if (createdStudent != null)
            {
                var groupInfo = createdStudent.group != null ? $"Group ID: {createdStudent.group.Id}, Name: {createdStudent.group.Name}" : "No group assigned";


                ConsoleHelper.MsgColor(ConsoleColor.Cyan, $"Student created - ID: {createdStudent.Id}, Name: {createdStudent.Name} {createdStudent.Surname}, Age: {createdStudent.Age}, {groupInfo}");
            }
            else
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Student creation failed. Please try again.");
            }
        }

        public void UpdateStudent()
        {
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Enter the student ID to update:");
        UpdateIdInput: string? idInput = Console.ReadLine();
            if (!int.TryParse(idInput?.Trim(), out int id))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid ID. Only numbers are allowed.");
                goto UpdateIdInput;
            }

            var existing = studentService.GetStudentById(id);
            if (existing == null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, $"Student with ID {id} not found.");
                return;
            }

            ConsoleHelper.MsgColor(ConsoleColor.Yellow, $"Enter student name (leave empty to keep \"{existing.Name}\"):");
            string? name = Console.ReadLine();
            ConsoleHelper.MsgColor(ConsoleColor.Yellow, $"Enter student surname (leave empty to keep \"{existing.Surname}\"):");
            string? surname = Console.ReadLine();

            ConsoleHelper.MsgColor(ConsoleColor.Yellow, $"Enter student age (leave empty to keep \"{existing.Age}\"):");
        NewAgeInput: string? ageInput = Console.ReadLine();
            int ageValue = existing.Age;
            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                if (!int.TryParse(ageInput.Trim(), out ageValue))
                {
                    ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid age. Try again.");
                    goto NewAgeInput;
                }
            }

            ConsoleHelper.MsgColor(ConsoleColor.Yellow, $"Enter group Id (leave empty to keep current group {(existing.group != null ? existing.group.Id.ToString() : "none")}):");
        NewGroupInput: string? groupInput = Console.ReadLine();
            Group? groupRef = existing.group;
            if (!string.IsNullOrWhiteSpace(groupInput))
            {
                if (!int.TryParse(groupInput.Trim(), out int gid))
                {
                    ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid group id. Try again.");
                    goto NewGroupInput;
                }
                groupRef = new Group { Id = gid }; 
            }

            Student updated = new()
            {
                Name = string.IsNullOrWhiteSpace(name) ? existing.Name : name.Trim(),
                Surname = string.IsNullOrWhiteSpace(surname) ? existing.Surname : surname.Trim(),
                Age = ageValue,
                group = groupRef
            };

            var result = studentService.UpdateStudent(id, updated);
            if (result != null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Green, $"Student with ID {id} updated successfully.");
            }
            else
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Update failed.");
            }
        }

        public void GetStudentById()
        {
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Enter the student ID:");
        GetByIdInput: string? idInput = Console.ReadLine();
            if (!int.TryParse(idInput?.Trim(), out int id))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid ID. Only numbers are allowed.");
                goto GetByIdInput;
            }

            var student = studentService.GetStudentById(id);
            if (student == null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, $"Student with ID {id} not found.");
                return;
            }

            var groupInfo = student.group != null ? $"Group ID: {student.group.Id}, Name: {student.group.Name}" : "No group assigned";
            ConsoleHelper.MsgColor(ConsoleColor.Cyan, $"Student Info - ID: {student.Id}, Name: {student.Name} {student.Surname}, Age: {student.Age}, {groupInfo}");
        }

        public void GetAllStudents()
        {
            var students = studentService.GetAllStudents() ?? new List<Student>();
            if (students.Count == 0)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Yellow, "No students found.");
                return;
            }

            foreach (var s in students)
            {
                var groupInfo = s.group != null ? $"Group ID: {s.group.Id}, Name: {s.group.Name}" : "No group";
                ConsoleHelper.MsgColor(ConsoleColor.Green, $"Student - ID: {s.Id}, Name: {s.Name} {s.Surname}, Age: {s.Age}, {groupInfo}");
            }
        }

        public void DeleteStudentById()
        {
            ConsoleHelper.MsgColor(ConsoleColor.Yellow, "Enter the student ID to delete:");
        DeleteIdInput: string? idInput = Console.ReadLine();
            if (!int.TryParse(idInput?.Trim(), out int id))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid ID. Only numbers are allowed.");
                goto DeleteIdInput;
            }

            studentService.DeleteStudent(id);
        }

        public void GetStudentByName() 
        {
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Enter student name:");
            string? studentName = Console.ReadLine().Trim();
            Student[] studentByName = studentService.GetStudentsByName(m => m.Name != null && m.Name.Equals(studentName, StringComparison.OrdinalIgnoreCase)).ToArray();
            foreach (var student in studentByName) 
            {
                var groupInfo = student.group != null ? $"Group ID: {student.group.Id}, Name: {student.group.Name}" : "No group";
                ConsoleHelper.MsgColor(ConsoleColor.Green, $"Student ID: {student.Id} ,student name: {student.Name}, student surname: {student.Surname}, student age: {student.Age}, student group: {groupInfo}");
            }
        }

        public void GetStudentByAge() 
        {
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Enter student age:");
        AgeInput: string? ageInput = Console.ReadLine();
            if (!int.TryParse(ageInput?.Trim(), out int age))
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Invalid age. Only numbers are allowed.");
                goto AgeInput;
            }

            var students = studentService.GetStudentByAge(m => m.Age == age).ToArray();
            if (students.Length == 0)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Yellow, $"No students found with age {age}.");
                return;
            }

            foreach (var student in students)
            {
                var groupInfo = student.group != null ? $"Group ID: {student.group.Id}, Name: {student.group.Name}" : "No group";
                ConsoleHelper.MsgColor(ConsoleColor.Green, $"Student ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, {groupInfo}");
            }
        }
    }
}