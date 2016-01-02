using System;
using System.Collections.Generic;
using DomainModel;

namespace Contracts.Repository
{
    public interface Repository<T> where T : Entity {
        T Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        T Find(T entity);
        T FindById(int id);
        IEnumerable<T> FindAll();
    }

}
