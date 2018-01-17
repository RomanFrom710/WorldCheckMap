using System;
using Microsoft.AspNetCore.Mvc;
using WorldCheckMap.Services.Commands;
using WorldCheckMap.Services.Dto;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("/:id")]
        public AccountDto Get(int id)
        {
            return _accountService.GetAccount(id);
        }

        [HttpGet]
        [Route("/:guid")]
        public AccountDto Get(Guid guid)
        {
            return _accountService.GetAccount(guid);
        }

        [HttpPost]
        [Route("/")]
        public AccountDto AddAccount(AddAccountCommand command)
        {
            return _accountService.AddAccount(command);
        }

        [HttpPut]
        [Route("/")]
        public void UpdateCountryState(UpdateCountryStateCommand command)
        {
            _accountService.UpdateCountryState(command);
        }
    }
}