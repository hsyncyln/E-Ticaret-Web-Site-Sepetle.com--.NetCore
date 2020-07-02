using System.Collections.Generic;

namespace ETicaret.Core.Base
{
    public interface IRepository<T>
    {

        void Update(T entity);
        void Insert(T entity);
        void Delete(T entity);
        IEnumerable<T> Get();
        T Get(int id);
        int Commit();
    }
}
