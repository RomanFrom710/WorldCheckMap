using System;
using Microsoft.AspNetCore.Mvc;
using WorldCheckMap.Services.Commands;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var account = _accountService.GetAccount(id);
            if (account == null)
            {
                return new NotFoundResult();
            }

            return new JsonResult(account);
        }

        [HttpGet("{guid:guid}")]
        public IActionResult Get(Guid guid)
        {
            var account = _accountService.GetAccount(guid);
            if (account == null)
            {
                return new NotFoundResult();
            }

            return new JsonResult(account);
        }

        [HttpPost("")]
        public IActionResult AddAccount([FromBody] AddAccountCommand command)
        {
            var newAccount = _accountService.AddAccount(command);
            return new JsonResult(newAccount);
        }

        [HttpPut("")]
        public IActionResult UpdateCountryState([FromBody] UpdateCountryStateCommand command)
        {
            _accountService.UpdateCountryState(command);
            return new NoContentResult();
        }
    }
}