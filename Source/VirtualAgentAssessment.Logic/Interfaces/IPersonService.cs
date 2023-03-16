using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Logic.Models;

namespace VirtualAgentAssessment.Logic.Interfaces
{
    public interface IPersonService
    {
        List<PersonDto> GetPersonDtos(string searchType, string searchTerm);
        void SavePerson(PersonDto personDto);
        PersonDto GetPersonDto(int code);
        void DeletePerson(int code);
        void EditPerson(PersonDto personDto);
    }
}
