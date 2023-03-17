using System.Collections.Generic;
using VirtualAgentAssessment.Domain.Models;

namespace VirtualAgentAssessment.Logic.Interfaces
{
    public interface IAccountService
    {
        List<AccountDto> GetAccountsFromPersonCode(int personCode);
        void SaveAccount(AccountDto accountDto);
    }
}