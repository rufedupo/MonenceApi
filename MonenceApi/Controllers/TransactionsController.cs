using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonenceApi.Models;
using MonenceApi.Models.Jsons;
using MonenceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonenceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private ITransactionService _transactionService;
        private IAccountService _accountService;

        public TransactionsController(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<Transaction>> Get(int id)
        {
            try
            {
                var transaction = await _transactionService.GetById(id);
                return Ok(transaction);
            }
            catch
            {
                return BadRequest("Não foi possível encontrar este id.");
            }
        }

        [HttpGet("{accountId}")]
        public async Task<ActionResult<IAsyncEnumerable<Transaction>>> GetAll(int accountId)
        {
            try
            {
                var transactions = await _transactionService.GetAll(accountId);
                return Ok(transactions);
            }
            catch
            {
                return BadRequest("Conta inválida");
            }
        }

        [HttpGet("{accountId}/{initialDate}/{finalDate}")]
        public async Task<ActionResult<IAsyncEnumerable<Transaction>>> GetByDate(int accountId, DateTime initialDate, DateTime finalDate)
        {
            try
            {
                var transactions = await _transactionService.GetAll(accountId);
                return Ok(transactions);
            }
            catch
            {
                return BadRequest("Conta inválida");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> AddEntry([FromBody] JsonTransaction jsonTransaction)
        {
            try
            {
                await _transactionService.AddEntry(jsonTransaction.AccountId, jsonTransaction.Amount);
                return Ok("Transação efetuada com sucesso!");
            }
            catch
            {
                return BadRequest("Não foi possível criar uma transação.");
            }
        }
    }
}
