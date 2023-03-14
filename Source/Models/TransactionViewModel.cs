using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualAgentAssessment.Models
{
    public class TransactionViewModel
    {
        public int code { get; set; }
        public DateTime transaction_date { get; set; }
        public DateTime capture_date { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
    }
}