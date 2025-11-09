using Domain.Models;
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll(Predicate<Student>? predicate)
        {
            throw new NotImplementedException();
        }

        public Student? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Student data)
        {
            throw new NotImplementedException();
        }
    }
}
