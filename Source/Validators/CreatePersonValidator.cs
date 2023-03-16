using FluentValidation;
using VirtualAgentAssessment.Models;
using VirtualAgentAssessment.Repositories.Interfaces;

namespace VirtualAgentAssessment.Validators
{
    public class CreatePersonValidator:AbstractValidator<PersonViewModel>
    {
        private IPersonRepository _personRepository;

        public CreatePersonValidator(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _setUpRules();
        }

        public void _setUpRules()
        {
            RuleFor(model => model.id_number)
                .Must(IsIdNumberInNotUse)
                .WithMessage("Person with same IdNumber already exists");
        }

        private bool IsIdNumberInNotUse(PersonViewModel model, string idNumber)
        {
            var person = _personRepository.GetPersonWithIdNumber(model.id_number);
            if (person != null)
            {
                return false;
            }
            return true;
        }
    }
}