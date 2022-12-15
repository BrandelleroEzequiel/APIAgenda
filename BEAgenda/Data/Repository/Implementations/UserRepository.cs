using BEAgenda.Data.Repository.Interfaces;
using BEAgenda.Entities;
using BEAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace BEAgenda.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AplicationDbContext _context;

        public UserRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }

        public async Task<User> AddUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetListUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task UpdateUser(User user)
        {
            var userItem = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (userItem != null)
            {
                userItem.Name = user.Name;
                userItem.Password = user.Password;
                userItem.Email = user.Email;
                userItem.UserName = user.UserName;

                await _context.SaveChangesAsync();
            }
        }

 
    }
}
