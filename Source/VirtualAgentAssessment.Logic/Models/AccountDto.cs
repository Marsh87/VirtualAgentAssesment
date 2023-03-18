using System.Collections.Generic;

namespace VirtualAgentAssessment.Logic.Models
{
    public class AccountDto
    {
        public AccountDto()
        {
            Transactions = new List<TransactionDto>();
        }
        public int code {  get; set; }  
        public int person_code { get; set; }
        public string account_number { get; set; }
        public decimal outstanding_balance { get; set;}
        public  bool IsActive { get; set; }
        
        public List<TransactionDto> Transactions { get; set; }
    }
}
