using System.Collections.Generic;
using VirtualAgentAssessment.Domain.Models;

namespace VirtualAgentAssessment.Logic.Models
{
    public class PersonDto
    {
        public PersonDto()
        {
            Accounts = new List<AccountDto>();
        }
        public int code { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string id_number { get; set; }
        
        public List<AccountDto> Accounts { get; set; }
    }
}
