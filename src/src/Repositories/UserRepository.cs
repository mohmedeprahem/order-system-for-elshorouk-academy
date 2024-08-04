using System;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;

namespace src.Repositories
{
    public class UserRepository
    {
        private readonly DBContext _dbContext;

        public UserRepository(DBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<User> Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
            _dbContext.SaveChanges();

            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
