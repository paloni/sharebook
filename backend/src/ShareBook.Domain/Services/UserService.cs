using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShareBook.Domain.Entities;
using ShareBook.Domain.Exceptions;
using ShareBook.Domain.Interfaces;

namespace ShareBook.Domain.Services
{
    public interface IUserService
    {
        Task<bool> UserExistAsync(string userName);
        Task<bool> CreateUserAsync(string email, string userName, string password);

        Task<string> GetUserIdByName(string userName);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository _userRepository)
        {
            this._userRepository = _userRepository ?? throw new ArgumentNullException(nameof(_userRepository));
        }
        public async Task<bool> CreateUserAsync(string email, string userName, string password)
        {
            return await _userRepository.CreateUserAsync(email, userName, password);
        }

        public async Task<bool> UserExistAsync(string userName)
        {
            return await _userRepository.UserExistAsync(userName);
        }
        public async Task<string> GetUserIdByName(string userName)
        {
            return await _userRepository.GetUserIdByName(userName);
        }
    }
}