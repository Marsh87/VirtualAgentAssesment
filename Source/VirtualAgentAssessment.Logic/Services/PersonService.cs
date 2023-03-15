using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Repositories.Interfaces;

namespace VirtualAgentAssessment.Logic.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository,IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public List<PersonDto> GetPersonDtos(string searchType, string searchTerm)
        {
            var persons = new List<Person>();
            switch (searchType)
            {
                case "Id Number":
                    persons = _personRepository.GetAllPeopleWithIdNumber(searchTerm);
                    break;
                case "Account Number":
                    persons = _personRepository.GetAllPeopleWithAccountNumber(searchTerm);
                    break;
                case "Surname":
                   persons = _personRepository.GetAllPeopleWithSurname(searchTerm);
                    break;
                default:
                    persons = _personRepository.GetAllPeople().ToList();
                    break;
            }
            return _mapper.Map<List<Person>, List<PersonDto>>(persons);
        }
    }
}
