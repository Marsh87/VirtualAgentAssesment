using FluentValidation;
using VirtualAgentAssessment.Models;
using VirtualAgentAssessment.Repositories.Interfaces;

namespace VirtualAgentAssessment.Validators
{
    public class EditAccountValidator:AbstractValidator<AccountViewModel>
    {
        private IAccountRepository _accountRepository;

        public EditAccountValidator(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _setUpRules();
        }

        public void _setUpRules()
        {
            RuleFor(model => model.account_number)
                .Must(IsAccountNumberNotInUse)
                .WithMessage("Account Number already exists");
        }

        private bool IsAccountNumberNotInUse(AccountViewModel model, string idNumber)
        {
            var originalAccount = _accountRepository.GetAccountFromCode(model.code);
            if (originalAccount.account_number != model.account_number)
            {
                var account = _accountRepository.GetAccountForAccountNumber(model.account_number);
                if (account != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}