using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAgentAssessment.Domain.Models
{
    public class SearchType
    {
        public enum SearchCategoryType
        {
            None = 0,
            IdNumber = 1,
            AccoutNumber =2,
            Surname = 3,
        }
    }
}
