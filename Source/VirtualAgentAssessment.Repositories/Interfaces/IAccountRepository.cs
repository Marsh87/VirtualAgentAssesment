using System.Collections.Generic;
using VirtualAgentAssessment.Domain.Models;

namespace VirtualAgentAssessment.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccountsForPerson(int personCode);
        Account GetAccountForAccountNumber(string accountNumber);
        void SaveAccount(Account account);
        Account GetAccountFromCode(int code);
        void SetAccountStatus(int code, bool status);
        void UpdateAccountNumber(int code, string accountNumber);
    }
}