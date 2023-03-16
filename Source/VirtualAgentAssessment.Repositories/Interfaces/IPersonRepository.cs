using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAgentAssessment.Domain.Models;

namespace VirtualAgentAssessment.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPeople();
        List<Person> GetAllPeopleWithIdNumber(string searchTerm);
        List<Person> GetAllPeopleWithAccountNumber(string searchTerm);
        List<Person> GetAllPeopleWithSurname(string searchTerm);
        Person GetPersonWithIdNumber(string idNumber);
        void SavePerson(Person person);
        Person GetPersonWithCode(int code);
        void DeletePerson(int code);
    }
}
