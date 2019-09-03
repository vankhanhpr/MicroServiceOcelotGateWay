using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainServer.responsitory
{
    public interface IResponsitory<T> where T : class
    {
        IEnumerable<T> getAll();
        T getById(object id);
        void insert(T obj);
        void update(T obj);
        void delete(object id);
        void save();
    }
}
