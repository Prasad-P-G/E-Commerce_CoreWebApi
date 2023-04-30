using Ecommerce_Core_WebApi.DataContext;
using Ecommerce_Core_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Core_WebApi.Repository
{
    public class UserRepositoty : IUserRepositoty
    {
        private ApplicationDbContext _context;
        public UserRepositoty(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<user> addUser(user user)
        {
            var result = await _context.Users.AddAsync(user);   
                          _context.SaveChanges();
            return result.Entity;
        }

        public async Task<user> GetUser(user user)
        {
            var existUser = await _context.Users.FirstOrDefaultAsync(u=>u.email == user.email && u.password == user.password);

            if (existUser != null)
            {
                return existUser;
            }
            return null;
            
        }

        public async Task<user> Search(user user)
        {
            try
            {
                return await _context.Users.FirstAsync(u => u.name == user.name);
            }
            catch(Exception)
            {
                throw;
            }

            
        }
    }
}
