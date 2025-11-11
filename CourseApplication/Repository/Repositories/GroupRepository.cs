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
            Group group = AppDbContext<Group>.datas.Find(m => m.Id == id);
            AppDbContext<Group>.datas.Remove(group);
        }
        // Butun Group-lari getirir
        public List<Group> GetAll(Predicate<Group>? predicate)
        {
            List<Group> groups = AppDbContext<Group>.datas;
            return groups;
        }

        public List<Group> GetAllByName(Predicate<Group> predicate)
        {
            List<Group> groups = AppDbContext<Group>.datas.FindAll(predicate);
            return groups;
        }

        public List<Group> GetAllByRoom(Predicate<Group> predicate)
        {
            List<Group> groups = AppDbContext<Group>.datas.FindAll(predicate);
            return groups;
        }

        // Id-ye gore Group getirir
        public Group? GetById(Predicate<Group> predicate)
        {
            Group existData = AppDbContext<Group>.datas.Find(predicate);
            return existData;
        }
        // Group-u yenileyen method
        public void Update(int id, Group data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data is empty.");

                Group existGroup = AppDbContext<Group>.datas.Find(m => m.Id == id);
                existGroup.Name = data.Name;
                existGroup.Teacher = data.Teacher;
                existGroup.Room = data.Room;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
