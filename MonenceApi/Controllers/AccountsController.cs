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
                if (account == null)
                {
                    await _accountService.Create(email);
                    account = await _accountService.GetByEmail(email);
                }

                return Ok(account);
            }
            catch
            {
                return BadRequest("Ocorreu um erro no servidor!");
            }
        }
    }
}
