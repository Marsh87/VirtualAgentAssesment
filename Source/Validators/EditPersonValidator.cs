using FluentValidation;
using VirtualAgentAssessment.Models;
using VirtualAgentAssessment.Repositories.Interfaces;

namespace VirtualAgentAssessment.Validators
{
    public class EditPersonValidator:AbstractValidator<EditPersonViewModel>
    {
        private IPersonRepository _personRepository;

        public EditPersonValidator(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _setUpRules();
        }

        public void _setUpRules()
        {
            RuleFor(model => model.id_number)
                .Must(IsIdNumberNotInUse)
                .WithMessage("Person with same Id Number already exists");
        }

        private bool IsIdNumberNotInUse(PersonViewModel model, string idNumber)
        {
            var originalPerson = _personRepository.GetPersonWithCode(model.code);
            if (originalPerson.id_number != model.id_number)
            {
                var person = _personRepository.GetPersonWithIdNumber(model.id_number);
                if (person != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}