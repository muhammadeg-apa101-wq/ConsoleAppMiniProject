using Domain.Models;
using Repository.Data;
using Repository.Repositories;
using Service.Helper;
using Service.Services.Interfaces;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Service.Services
{
    public class StudentService : IStudentInterface
    {
        private readonly StudentRepository _studentRepository;
        private readonly GroupRepository _groupRepository;
        public int count;

        public StudentService()
        {
            _studentRepository = new();
            _groupRepository = new();           
            try { count = AppDbContext<Student>.datas?.Count ?? 0; } catch { count = 0; }
        }

        public Student CreateStudent(Student student)
        {
            if (student == null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Student is null.");
                return null;
            }

            
            student.Name = student.Name?.Trim();
            student.Surname = student.Surname?.Trim();

           
            if (student.group != null && student.group.Id > 0)
            {
                var grp = _groupRepository.GetById(m => m.Id == student.group.Id);
                student.group = grp; 
            }

            if (!StudentValidator.Validate(student))
            {
                return null;
            }

            student.Id = ++count;
            _studentRepository.Create(student);
            ConsoleHelper.MsgColor(ConsoleColor.Green, "Student successfully created!");
            return student;
        }

        public Student UpdateStudent(int id, Student student)
        {
            if (student == null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Student is null.");
                return null;
            }

            student.Name = student.Name?.Trim();
            student.Surname = student.Surname?.Trim();

            if (student.group != null && student.group.Id > 0)
            {
                var grp = _groupRepository.GetById(m => m.Id == student.group.Id);
                student.group = grp;
            }

            if (!StudentValidator.Validate(student))
            {
                return null;
            }

            student.Id = id;
            _studentRepository.Update(id, student);
            ConsoleHelper.MsgColor(ConsoleColor.Green, $"Student with ID {id} updated.");
            return student;
        }

        public Student GetStudentById(int id)
        {
            var student = _studentRepository.GetById(m => m.Id == id);
            if (student == null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, $"Student with ID {id} not found.");
                return null;
            }
            return student;
        }

        public List<Student> GetAllStudents(Predicate<Student>? predicate = null)
        {
            return _studentRepository.GetAll(predicate) ?? new List<Student>();
        }


        public void DeleteStudent(int id)
        {
            var existing = _studentRepository.GetById(m => m.Id == id);
            if (existing == null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, $"Student with ID {id} not found.");
                return;
            }

            _studentRepository.Delete(id);
            ConsoleHelper.MsgColor(ConsoleColor.Green, $"Student with ID {id} has been deleted.");
        }

        public List<Student> GetGroupByStudent(Predicate<Student>? predicate = null)
        {
            return new List<Student>();

        }

        public List<Student> GetStudentsByName(Predicate<Student>? predicate = null)
        {
            if (predicate == null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Please provide a name to search.");
                return new List<Student>();
            }

            var existing = _studentRepository.GetAllByName(predicate);
            if (existing == null || existing.Count == 0)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "No student found matching this name. Enter correctly or enter another.");
                return new List<Student>();
            }

            return existing;
        }

        public List<Student> GetStudentByAge(Predicate<Student>? predicate = null)
        {
            if (predicate == null)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "Please provide an age to search.");
                return new List<Student>();
            }

            var existing = _studentRepository.GetAll(predicate);
            if (existing == null || existing.Count == 0)
            {
                ConsoleHelper.MsgColor(ConsoleColor.Red, "No student found matching this age.");
                return new List<Student>();
            }

            return existing;
        }
    }
}
