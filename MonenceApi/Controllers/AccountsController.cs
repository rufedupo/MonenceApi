using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonenceApi.Models;
using MonenceApi.Services;
using MonenceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonenceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IAsyncEnumerable<Account>>> Get(string email)
        {
            try
            {
                var account = await _accountService.GetByEmail(email);
                return Ok(account);
            }
            catch
            {
                return BadRequest("Não foi possível encontrar este email.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<IAsyncEnumerable<Account>>> Register(string email)
        {
            try
            {
                Account account = new Account
                {
                    Email = email
                };
                await _accountService.Create(account);
                return Ok("Conta criada com sucesso!");
            }
            catch
            {
                return BadRequest("Não foi possível criar conta.");
            }
        }
    }
}
