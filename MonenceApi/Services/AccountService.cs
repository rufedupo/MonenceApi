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

        public async Task Create(string email)
        {
            try
            {
                _context.Accounts.Add(new Account { Email = email });
                await _context.SaveChangesAsync();
            }
            catch
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

        public async Task<Account> GetById(int id)
        {
            try
            {

                return await _context.Accounts.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(Account account)
        {
            try
            {
                _context.Entry(account).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
