using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAgentAssessment.Domain.Models
{
    public class Account
    {
        public int code {  get; set; }  
        public string person_code { get; set; }
        public string account_number { get; set; }
     
        public decimal outstanding_balance { get; set;}
        public virtual ICollection<Transaction>  Transactions { get; set; }
    }
}
