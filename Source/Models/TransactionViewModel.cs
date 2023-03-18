using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualAgentAssessment.Models
{
    public class TransactionViewModel
    {
        [Required]
        public int code { get; set; }
        [Required]
        [DisplayName("Transaction Date")]
        public DateTime transaction_date { get; set; }
        [DisplayName("Capture Date")]
        public DateTime capture_date { get; set; }
        [Required]
        [DisplayName("Amount")]
        public decimal amount { get; set; }
        [Required]
        [DisplayName("Description")]
        [MaxLength(100)]
        public string description { get; set; }
    }
}