using DAWW.Models;

namespace DAWW.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUseri();
        User GetUserById(int id);
        User GetUserByMail(string mail);
        bool UserExists(string email);
        bool UserExistsById(int id);

        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
