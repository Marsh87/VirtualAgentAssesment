
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAgentAssessment.Domain.Models
{
    public class Transaction
    {
        [Key]
        public int code {  get; set; }
        public DateTime transaction_date { get; set; }
        public DateTime capture_date { get; set;}
        public decimal amount { get; set; }
        public string description { get; set; }
    }
}
