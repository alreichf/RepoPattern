using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interview.Entity;

namespace Interview.Repository
{
    // Please create an in memory implementation of IRepository<T> 

    public interface IRepository<T> where T : IStoreable
    {
        Task<IEnumerable<T>> All();
        void Delete(IComparable id);
        void Save(T item);
        T FindById(IComparable id);
    }
}
