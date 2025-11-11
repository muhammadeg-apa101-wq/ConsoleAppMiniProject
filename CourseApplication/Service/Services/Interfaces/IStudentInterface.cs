using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentInterface
    {
        Student CreateStudent(Student student);
        Student UpdateStudent(int id, Student student);
        Student GetStudentById(int id);
        List<Student> GetAllStudents(Predicate<Student>? predicate = null);
        List<Student> GetGroupByStudent(Predicate<Student>? predicate = null);
        List<Student> GetStudentsByName(Predicate<Student>? predicate = null);
        List<Student> GetStudentByAge(Predicate<Student>? predicate = null);
        void DeleteStudent(int id);
    }
}
