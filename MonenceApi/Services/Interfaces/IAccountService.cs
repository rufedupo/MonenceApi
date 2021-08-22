using MonenceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonenceApi.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetByEmail(string email);

        Task Create(Account account);
    }
}
