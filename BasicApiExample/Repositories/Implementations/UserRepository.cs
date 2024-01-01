using BasicApiExample.Context;
using BasicApiExample.Models;
using BasicApiExample.Repositories.Interfaces;

namespace BasicApiExample.Repositories.Implementations
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public User CreateUser(User user)
        {
            var users = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Phone = user.Phone,
            };
            _context.users.Add(users);
            _context.SaveChanges();
            if(users !=null)
            {
                return users;
            }
            else
            {
                return null;
            }
            
        }

        public void DeleteUser(int id)
        {
            var user = _context.users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                _context.users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        public User GetUserById(int id)
        {
            var user = _context.users.Where(u => u.Id == id).FirstOrDefault();
            if(user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public ICollection<User> GetUsersPg(int page, int dataSize)
        {
            
            //if(page <=1)
            //{
            //    page = 0;
            //}
            int totalNumber = page * dataSize;
            var user = _context.users.Skip(totalNumber).Take(dataSize).ToList();
            if(user.Count > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public ICollection<User> SearchUser(string name)
        {
            var user = _context.users.Where(n=>n.Name.ToLower() == name.ToLower()).ToList();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
            
        }

        public ICollection<User> SearchUsers(string text)
        {
            var users = _context.users.Where(c => c.Name.ToLower().Contains(text.ToLower()) || c.Phone.ToLower().Contains(text.ToLower()));
            if(users.Count() != 0)
            {
                return users.ToList();
            }
            else
            {
                return null;
            }
            
        }

        public User UpdateUser(User user)
        {
            var updatedUser = _context.users.Where(u=>u.Id == user.Id).FirstOrDefault();
            if(updatedUser != null)
            {
                updatedUser.Name = user.Name;
                updatedUser.Email = user.Email;
                updatedUser.Password = user.Password;
                updatedUser.Address = user.Address;
                updatedUser.Phone = user.Phone;
                _context.users.Update(updatedUser);
                _context.SaveChanges();
                return updatedUser;
            }
            else
            {
                return null;
            }

        }

        public IEnumerable<User> Users()
        {
          
            var users = _context.users.OrderByDescending(c=>c.Id).ThenByDescending(n=>n.Name).ToList();
            if(users !=null)
            {
                return users;
            }
            else
            {
                return null;
            }
        }

        
    }
}
