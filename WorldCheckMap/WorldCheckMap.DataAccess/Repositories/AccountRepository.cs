using System;
using System.Linq;
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
            return _context.Accounts.FirstOrDefault(a => a.Guid == guid);
        }

        public Account GetAccount(int id)
        {
            return _context.Accounts.Find(id);
        }

        public int AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account.Id;
        }

        public void UpsertCountryState(Guid guid, CountryState countryState)
        {
            throw new NotImplementedException();
        }
    }
}