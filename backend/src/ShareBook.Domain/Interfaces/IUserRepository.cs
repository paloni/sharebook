using System.Collections.Generic;
using System.Threading.Tasks;
using ShareBook.Domain.Entities;

namespace ShareBook.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExistAsync(string userName);
        Task<bool> CreateUserAsync(string email, string userName, string password);
    }
}