using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAgentAssessment.Domain.Models
{
    public class Person
    {
        [Key]
        public int code { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string id_number { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
