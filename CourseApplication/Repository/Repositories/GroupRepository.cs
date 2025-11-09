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
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data is empty.");

                AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); 
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll(Predicate<Group>? predicate)
        {
            throw new NotImplementedException();
        }

        public Group? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Group data)
        {
            throw new NotImplementedException();
        }
    }
}
