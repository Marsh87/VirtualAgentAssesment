using VirtualAgentAssessment.Domain.Models;

namespace VirtualAgentAssessment.Logic.Interfaces
{
    public interface ITransactionService
    {
        TransactionDto GetTransaction(int code);
        void SaveTransaction(TransactionDto transaction);
        void UpdateTransaction(TransactionDto transaction);
    }
}