using BasicApiExample.Models;

namespace BasicApiExample.Repositories.Interfaces
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> Users();
        T Create(T entity);
        T Update(T entity);
        void Delete(int entity);
        User GetById(int entity);

        ICollection<T> SearchByName(string entity);

        ICollection<T> Search(string entity);

        ICollection<User> GetUsersPg(int page, int dataSize);
    }
}
