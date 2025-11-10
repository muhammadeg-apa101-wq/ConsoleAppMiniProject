using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interface
{
    public interface IRepository<T> where T :  BaseEntity
    {
        void Create(T data);

        void Update(int id, T data);

        void Delete(int id);

        T? GetById(Predicate<T> predicate);

        List<T> GetAll(Predicate<T> predicate);
    }
}
