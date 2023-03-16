using System.Collections.Generic;
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
    }
}