using System.Collections.Generic;
using VirtualAgentAssessment.Domain.Models;

namespace VirtualAgentAssessment.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccountsForPerson(int personCode);
    }
}