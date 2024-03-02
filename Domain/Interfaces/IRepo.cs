using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepo<T> where T : Entity
    {
        List<T> GetAll();
        T CreateEntity(T entity);
        T FindById(int id);
        void Update(T entity);
        void DeleteById(int id);
        void CommitChanges();

    }
}
