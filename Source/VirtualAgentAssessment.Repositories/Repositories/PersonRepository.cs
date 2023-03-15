using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAgentAssessment.Domain;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Repositories.Interfaces;

namespace VirtualAgentAssessment.Repositories.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private IVirtualAgentContext _virtualAgentContext;
        public PersonRepository(IVirtualAgentContext virtualAgentContext) 
        {
            _virtualAgentContext = virtualAgentContext;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _virtualAgentContext.People.ToList();
        }

        public List<Person> GetAllPeopleWithIdNumber(string searchTerm)
        {
            return _virtualAgentContext.People.Where(x => x.id_number.Contains(searchTerm)).ToList();
        }

        public List<Person> GetAllPeopleWithAccountNumber(string searchTerm)
        {
            return _virtualAgentContext.People.Where(p => p.Accounts.Any(c => c.account_number.Contains(searchTerm) && c.IsActive))
                .ToList();
        }

        public List<Person> GetAllPeopleWithSurname(string searchTerm)
        {
            return _virtualAgentContext.People.Where(p => p.surname.Contains(searchTerm)).ToList();
        }
    }
}
