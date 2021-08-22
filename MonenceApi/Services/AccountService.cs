using Microsoft.EntityFrameworkCore;
using MonenceApi.Context;
using MonenceApi.Models;
using MonenceApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonenceApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
            }catch
            {
                throw;
            }
        }

        public async Task<Account> GetByEmail(string email)
        {
            try
            {

                return await _context.Accounts.Where(a => a.Email == email).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
