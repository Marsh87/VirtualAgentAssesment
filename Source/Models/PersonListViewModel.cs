using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualAgentAssessment.Models
{
    public class PersonListViewModel
    {
        public List<PersonViewModel> Persons { get; set; }
        public List<SelectListItem> FilterCategories { get; set; }
    }
}