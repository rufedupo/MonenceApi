using MonenceApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonenceApi.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAll(int accountId);

        Task<Transaction> GetById(int id);

        Task<IEnumerable<Transaction>> GetByDate(DateTime initialDate, DateTime finalDate);

        Task Create(Transaction transaction);

        Task AddEntry(int accountId, decimal amount);
    }
}
