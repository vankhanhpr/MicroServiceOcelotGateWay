using AuthServer.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainServer.responsitory.impl
{
    public class Responsitory<T> : IResponsitory<T> where T : class
    {
        private DataContext m_context;
        protected DbSet<T> m_table = null;
        public Responsitory(DataContext context)
        {
            m_context = context;
            m_table = m_context.Set<T>();
        }
        public void delete(object id)
        {
            T obj = m_table.Find(id);
            m_table.Remove(obj);
            save();
        }
        public void insert(T obj)
        {
            m_table.Add(obj);
            save();
        }
        public void save()
        {
            m_context.SaveChanges();
        }
        public IEnumerable<T> getAll()
        {
            return m_table.ToList();
        }
        public T getById(object id)
        {
            return m_table.Find(id);
        }
        public void update(T obj)
        {
            m_context.Add(obj).State = EntityState.Added;
            save();
        }
    }
}
