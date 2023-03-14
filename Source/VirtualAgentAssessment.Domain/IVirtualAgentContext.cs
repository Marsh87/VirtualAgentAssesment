using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAgentAssessment.Domain.Models;

namespace VirtualAgentAssessment.Domain
{
    public interface IVirtualAgentContext: IDisposable
    {
        IDbSet<Person> Persons { get; set; }
        IDbSet<Account> Accounts { get; set; }
        IDbSet<Transaction> Transactions { get; set; }
        int SaveChanges();
    }
}
