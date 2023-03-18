using System.Linq;
using VirtualAgentAssessment.Domain;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Repositories.Interfaces;
using VirtualAssessment.Common.Interface;

namespace VirtualAgentAssessment.Repositories.Repositories
{
    public class TransactionRepository:ITransactionRepository
    {
        private IVirtualAgentContext _virtualAgentContext;
        private IDateTimeProvider _dateTimeProvider;

        public TransactionRepository(
            IVirtualAgentContext virtualAgentContext, 
            IDateTimeProvider dateTimeProvider
            )
        {
            _virtualAgentContext = virtualAgentContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public Transaction GetTransactionFromCode(int code)
        {
           var transaction = _virtualAgentContext.Transactions.FirstOrDefault(x => x.code == code);
           return transaction;
        }

        public void SaveTransaction(Transaction transaction)
        {
            transaction.capture_date = _dateTimeProvider.GetDateTimeNow();
            _virtualAgentContext.Transactions.Add(transaction);
            _virtualAgentContext.SaveChanges();
        }
        
        public void UpdateTransaction(Transaction transaction)
        {
            var originalTransaction = _virtualAgentContext.Transactions.FirstOrDefault(x => x.code == transaction.code);
            if (originalTransaction != null)
            {
                originalTransaction.transaction_date = transaction.transaction_date;
                originalTransaction.amount = transaction.amount;
                originalTransaction.description = transaction.description;
                originalTransaction.capture_date = _dateTimeProvider.GetDateTimeNow();
            }
            _virtualAgentContext.SaveChanges();
        }
    }
}