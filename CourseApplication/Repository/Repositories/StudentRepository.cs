using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data is empty.");

                
                if (data.group != null && data.group.Id > 0)
                {
                    var grp = AppDbContext<Group>.datas.Find(g => g.Id == data.group.Id);
                    data.group = grp; 
                }

                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int id)
        {
            var student = AppDbContext<Student>.datas.Find(s => s.Id == id);
            if (student != null)
            {
                AppDbContext<Student>.datas.Remove(student);
            }
        }

        public List<Student> GetAll(Predicate<Student>? predicate)
        {
            if (AppDbContext<Student>.datas == null) return new List<Student>();
            if (predicate == null) return new List<Student>(AppDbContext<Student>.datas);
            return AppDbContext<Student>.datas.FindAll(predicate);
        }

        public List<Student> GetAllByName(Predicate<Student> predicate)
        {
            if (AppDbContext<Student>.datas == null) return new List<Student>();
            return AppDbContext<Student>.datas.FindAll(predicate);
        }

        public List<Student> GetAllByRoom(Predicate<Student> predicate)
        {
            if (AppDbContext<Student>.datas == null) return new List<Student>();
            return AppDbContext<Student>.datas.FindAll(predicate);
        }

        public Student? GetById(Predicate<Student> predicate)
        {
            if (AppDbContext<Student>.datas == null) return null;
            return AppDbContext<Student>.datas.Find(predicate);
        }

        public void Update(int id, Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data is empty.");

                var exist = AppDbContext<Student>.datas.Find(s => s.Id == id);
                if (exist == null) throw new NotFoundException($"Student with ID {id} not found.");

                
                exist.Name = data.Name;
                exist.Surname = data.Surname;
                exist.Age = data.Age;

               
                if (data.group != null && data.group.Id > 0)
                {
                    var grp = AppDbContext<Group>.datas.Find(g => g.Id == data.group.Id);
                    exist.group = grp;
                }
                else
                {
                    exist.group = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
