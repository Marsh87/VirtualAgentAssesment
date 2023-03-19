using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualAgentAssessment.Models
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            Accounts = new List<AccountViewModel>();
        }
        
        [Required]
        public int code { get; set; }
        [MaxLength(50)]
        [DisplayName("Name")]
        public string name { get; set; }
        [MaxLength(50)]
        [DisplayName("Surname")]
        public string surname { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Id Number")]
        public string id_number { get; set; }
        
        public List<AccountViewModel> Accounts { get; set; }
    }
}