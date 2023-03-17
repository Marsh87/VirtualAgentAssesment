using FluentValidation;
using VirtualAgentAssessment.Models;
using VirtualAgentAssessment.Repositories.Interfaces;

namespace VirtualAgentAssessment.Validators
{
    public class CloseAccountValidator:AbstractValidator<AccountViewModel>
    {
        private IAccountRepository _accountRepository;

        public CloseAccountValidator(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _setUpRules();
        }

        public void _setUpRules()
        {
            RuleFor(model => model.outstanding_balance)
                .NotEqual(0)
                .WithMessage("Cannot Close an account with balance that is not zero");
        }
    }
}