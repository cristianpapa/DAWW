using DAWW.Data;
using DAWW.Interfaces;
using DAWW.Models;

namespace DAWW.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public User GetUserById(int id)
        {
            return _context.Useri.Where(x => x.Id == id).FirstOrDefault();
        }

        public User GetUserByMail(string mail)
        {
            return _context.Useri.Where(x => x.Email == mail).FirstOrDefault();
        }

        public ICollection<User> GetUseri()
        {
            return _context.Useri.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            if (saved > 0)
                return true;
            return false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExists(string email)
        {
            var useri = _context.Useri.Where(x => x.Email == email);
            if(useri.Count() > 0)
                return true;
            return false;
        }

        public bool UserExistsById(int id)
        {
            var useri = _context.Useri.Where(x => x.Id == id);
            if (useri.Count() > 0)
                return true;
            return false;
        }
    }
}
