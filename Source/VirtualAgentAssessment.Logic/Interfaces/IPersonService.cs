using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAgentAssessment.Domain.Models;

namespace VirtualAgentAssessment.Logic.Interfaces
{
    public interface IPersonService
    {
        List<PersonDto> GetPersonDtos(string searchType, string searchTerm);
    }
}
