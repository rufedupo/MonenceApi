using MonenceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonenceApi.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetById(int id);

        Task<Account> GetByEmail(string email);

        Task Create(string email);

        Task Update(Account account);
    }
}
