using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAgentAssessment.Domain.Models
{
    public class Account
    {
        [Key]
        public int code {  get; set; }  
        public int person_code { get; set; }
        public string account_number { get; set; }
     
        public decimal outstanding_balance { get; set;}
        public virtual ICollection<Transaction>  Transactions { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("person_code")]
        public  virtual Person Person { get; set; }
    }
}
