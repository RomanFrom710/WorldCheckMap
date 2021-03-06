﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.DataAccess.Repositories.Interfaces;

namespace WorldCheckMap.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly WorldCheckMapContext _context;

        public AccountRepository(WorldCheckMapContext context)
        {
            _context = context;
        }

        public Account GetAccount(Guid guid)
        {
            return _context
                .Accounts
                .Include(a => a.CountryStates)
                .FirstOrDefault(a => a.Guid == guid);
        }

        public Account GetAccount(int id)
        {
            return _context
                .Accounts
                .Include(a => a.CountryStates)
                .FirstOrDefault(a => a.Id == id);
        }

        public int AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account.Id;
        }

        public void UpdateCountryState(Guid accountGuid, int countryId, CountryStatus countryStatus)
        {
            var account = GetAccount(accountGuid);
            if (account == null)
            {
                return;
            }

            var state = _context.CountryStates.FirstOrDefault(s =>
                s.AccountId == account.Id && s.CountryId == countryId);

            if (state == null)
            {
                _context.CountryStates.Add(new CountryState
                {
                    AccountId = account.Id,
                    CountryId = countryId,
                    Status = countryStatus
                });
            }
            else
            {
                state.Status = countryStatus;
            }

            _context.SaveChanges();
        }
    }
}
