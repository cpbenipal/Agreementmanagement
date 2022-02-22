using AMS.DbContext.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Repositories.Generic
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    { 

        private ApplicationDbContext _context = null;
        private DbSet<T> table = null;
        
        public RepositoryBase(ApplicationDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        } 
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public int Save()
        {
            return _context.SaveChanges();
        } 
    }
}
