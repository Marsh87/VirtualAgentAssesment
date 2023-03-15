using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAgentAssessment.Domain.Models;

namespace VirtualAgentAssessment.Domain
{
    public class VirtualAgentContext : DbContext, IVirtualAgentContext
    {
        public IDbSet<Person> People { get ; set; }
        public IDbSet<Account> Accounts { get ; set ; }
        public IDbSet<Transaction> Transactions { get; set; }

        public VirtualAgentContext() : base("DefaultConnection")
        {

        }

        static VirtualAgentContext()
        {
            Database.SetInitializer<VirtualAgentContext>(null);
        }
    }
}
