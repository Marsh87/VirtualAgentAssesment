using FluentValidation;
using VirtualAgentAssessment.Models;
using VirtualAssessment.Common.Interface;

namespace VirtualAgentAssessment.Validators
{
    public class TransactionValidator: AbstractValidator<TransactionViewModel>
    {
        private IDateTimeProvider _dateTimeProvider;
        
        public TransactionValidator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            _setUpRules();
        }

        public void _setUpRules()
        {
            RuleFor(x => x.transaction_date)
                .LessThan(_dateTimeProvider.GetDateTimeNow())
                .WithMessage("Transaction Date cannot be a future date");
            
            RuleFor(x => x.amount)
                .NotEqual(0)
                .WithMessage("Transaction Amount cannot be zero");
        }
    }
}