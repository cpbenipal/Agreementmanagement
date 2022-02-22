using System.Collections.Generic;

namespace AMS.Repositories.Generic
{
    public interface IRepository<T> where T : class
    { 
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        int Save(); 
    }
}
