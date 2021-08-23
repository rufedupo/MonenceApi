using Microsoft.EntityFrameworkCore;
using MonenceApi.Context;
using MonenceApi.Models;
using MonenceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonenceApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;
        private IAccountService _accountService;

        public TransactionService(AppDbContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        public async Task Create(Transaction transaction)
        {
            try
            {
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Transaction>> GetAll(int accountId)
        {
            try
            {
                return await _context.Transactions.Where(t => t.Account.Id == accountId).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Transaction>> GetByDate(DateTime initialDate, DateTime finalDate)
        {
            try
            {
                return await _context.Transactions.Where(t => t.Date >= initialDate && t.Date <= finalDate).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Transaction> GetById(int id)
        {
            try
            {
                return await _context.Transactions.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task AddEntry(int accountId, decimal amount)
        {
            try
            {
                var account = await _accountService.GetById(accountId);

                if (account == null)
                    throw new Exception();

                Transaction transaction = new Transaction
                {
                    Account =account,
                    Amount = amount,
                    Date = DateTime.Now
                };

                account.Amount = account.Amount + transaction.Amount;

                await Create(transaction);

                await _accountService.Update(account);
            }
            catch
            {
                throw;
            }
        }
    }
}
