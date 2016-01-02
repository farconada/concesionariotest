using System.Collections.Generic;
using DomainModel;

namespace Contracts.Service
{
    public interface Service <T> where T : Entity {
        T Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        T Find(T entity);
        IEnumerable<T> FindAll();

    }
}
