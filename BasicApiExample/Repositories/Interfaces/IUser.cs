using BasicApiExample.Models;

namespace BasicApiExample.Repositories.Interfaces
{
    public interface IUser
    {
         IEnumerable<User> Users();
         User CreateUser(User user);
         User UpdateUser(User user);
         void DeleteUser(int id);
         User GetUserById(int id);

        ICollection<User> SearchUser(string name);

        ICollection<User> SearchUsers(string text);

        ICollection<User> GetUsersPg(int page, int dataSize);


    }
}
