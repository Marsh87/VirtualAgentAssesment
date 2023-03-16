using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<Person> GetAllPeopleWithIdNumber(string searchTerm)
        {
            return _virtualAgentContext.People.Where(x => x.id_number.Contains(searchTerm)).ToList();
        }

        public IEnumerable<Person> GetAllPeopleWithAccountNumber(string searchTerm)
        {
            return _virtualAgentContext.People.Where(p => p.Accounts.Any(c => c.account_number.Contains(searchTerm) && c.IsActive))
                .ToList();
        }

        public IEnumerable<Person> GetAllPeopleWithSurname(string searchTerm)
        {
            return _virtualAgentContext.People.Where(p => p.surname.Contains(searchTerm)).ToList();
        }

        public Person GetPersonWithIdNumber(string idNumber)
        {
            return _virtualAgentContext.People.FirstOrDefault(x => x.id_number == idNumber);
        }

        public void SavePerson(Person person)
        {
            _virtualAgentContext.People.Add(person);
            _virtualAgentContext.SaveChanges();
        }

        public Person GetPersonWithCode(int code)
        {
            return _virtualAgentContext.People
                .Where(x => x.code == code)
                .Include(x=>x.Accounts)
                .FirstOrDefault();
        }

        public void DeletePerson(int code)
        {
            var person = _virtualAgentContext.People.FirstOrDefault(x => x.code == code);
            _virtualAgentContext.People.Remove(person);
            _virtualAgentContext.SaveChanges();
        }

        public void EditPerson(Person person)
        {
            var originalPerson= _virtualAgentContext.People.FirstOrDefault(x => x.code == person.code);
            originalPerson.id_number = person.id_number;
            originalPerson.surname = person.surname;
            originalPerson.name = person.name;
            _virtualAgentContext.SaveChanges();

        }
    }
}
