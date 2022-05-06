﻿using DAWW.Data;
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
        public bool UserExists(string email)
        {
            var useri = _context.Useri.Where(x => x.Email == email);
            if(useri.Count() > 0)
                return true;
            return false;
        }
    }
}