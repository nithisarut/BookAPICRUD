using Library.Models;
using Library.Service;
using LibraryAPI.DTOS.Account;
using LibraryAPI.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public ApiAccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromForm] AccountRequest accountRequest)
        {
            var account = accountRequest.Adapt<Account>();
            await accountService.Register(account);
            return Ok(new { msg = "OK" });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAccountAll()
        {
            return Ok((await accountService.GetAll()).Select(AccountResponse.FromAccount));
        }
    }
}
