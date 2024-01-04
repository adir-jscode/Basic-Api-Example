using BasicApiExample.Context;
using BasicApiExample.Models;
using BasicApiExample.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicApiExample.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public T Create(T entity)
        {
            dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            _context.SaveChanges();

        }

        public void Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public User GetById(T entity)
        {
            throw new NotImplementedException();
        }

        public User GetById(int entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetUsersPg(int page, int dataSize)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> Search(string entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> SearchByName(string entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Users()
        {
            throw new NotImplementedException();
        }
    }
}
