using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VirtualAgentAssessment.Domain;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Repositories.Interfaces;

namespace VirtualAgentAssessment.Repositories.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly IVirtualAgentContext _virtualAgentContext;

        public AccountRepository(IVirtualAgentContext virtualAgentContext)
        {
            _virtualAgentContext = virtualAgentContext;
        }
        public IEnumerable<Account> GetAccountsForPerson(int personCode)
        {
            return _virtualAgentContext.Accounts.Where(x => x.person_code == personCode).ToList();
        }

        public Account GetAccountForAccountNumber(string accountNumber)
        {
            return _virtualAgentContext.Accounts.FirstOrDefault(x => x.account_number == accountNumber);
        }

        public void SaveAccount(Account account)
        {
            _virtualAgentContext.Accounts.Add(account);
            _virtualAgentContext.SaveChanges();
        }

        public Account GetAccountFromCode(int code)
        {
            return _virtualAgentContext.Accounts
                .Where(x => x.code == code)
                .Include(x=>x.Transactions)
                .FirstOrDefault();;
        }

        public void SetAccountStatus(int code, bool status)
        {
            var account = _virtualAgentContext.Accounts.FirstOrDefault(x => x.code == code);
            if (account != null) account.IsActive = status;
            _virtualAgentContext.SaveChanges();
        }

        public void UpdateAccountNumber(int code, string accountNumber)
        {
            var account = _virtualAgentContext.Accounts.FirstOrDefault(x => x.code == code);
            if (account != null) account.account_number = accountNumber;
            _virtualAgentContext.SaveChanges();
        }

        public void UpdateOutstandingBalance(int code, decimal balance)
        {
            var account = _virtualAgentContext.Accounts.FirstOrDefault(x => x.code == code);
            if (account != null) account.outstanding_balance = balance;
            _virtualAgentContext.SaveChanges();        
        }
    }
}