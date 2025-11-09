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
        // Group elave eden method
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
        // Group silen method
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        // Butun Group-lari getirir
        public List<Group> GetAll(Predicate<Group>? predicate)
        {
            throw new NotImplementedException();
        }
        // Id-ye gore Group getirir
        public Group? GetById(int id)
        {
            throw new NotImplementedException();
        }
        // Group-u yenileyen method
        public void Update(int id, Group data)
        {
            throw new NotImplementedException();
        }
    }
}
