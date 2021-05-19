using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.Entity;
using Interview.Exceptions;

namespace Interview.Repository
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        private readonly IList<T> _entities;

        public Repository()
        {
            _entities = new List<T>();
        }

        public async Task<IEnumerable<T>> All()
        {
            return await Task.Run(() => _entities);
        }

        public void Delete(IComparable id)
        {
            var found = _entities.FirstOrDefault(e => e.Id.Equals(id));

            // throw exception if not found?
            if (null == found)
            {
                throw new EntityNotFoundException($"Entity with Id {id} Not Found");
            }

            _entities.Remove(found);
        }

        public T FindById(IComparable id)
        {
            return _entities.ToList().Find(e => id.Equals(e.Id));
        }

        public void Save(T item)
        {
            // check if it already exists
            var found = FindById(item.Id);
            if ( found is object)
            {
                throw new EntityExistsException($"Duplicate Entity with Id: {item.Id} found");
            }

            // add new item
            _entities.Add(item);
        }
    }
}
