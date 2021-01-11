using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShareBook.Domain.Entities;
using ShareBook.Domain.Interfaces;

namespace ShareBook.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShareBookDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(ShareBookDbContext _context, UserManager<AppUser> _userManager)
        {
            this._userManager = _userManager;
            this._context = _context;
        }

        public async Task<bool> CreateUserAsync(string email, string userName, string password)
        {
            bool userExist = await UserExistAsync(userName);

            if (userExist)
            {
                return false;
            }
            var user = new AppUser()
            {
                Email = email,
                UserName = userName
            };


            await _userManager.CreateAsync(user, password);

            return true;

        }

        public async Task<AppUser> GetUserByEmail(string userName)
        {
            return await _userManager.FindByNameAsync(userName);

        }

        public async Task<string> GetUserIdByName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user.Id;
        }

        public async Task<bool> UserExistAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName) != null;
        }
    }
}