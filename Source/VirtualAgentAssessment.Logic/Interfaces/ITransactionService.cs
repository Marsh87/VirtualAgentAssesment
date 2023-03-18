using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Logic.Models;

namespace VirtualAgentAssessment.Logic.Interfaces
{
    public interface ITransactionService
    {
        TransactionDto GetTransaction(int code);
        void SaveTransaction(TransactionDto transaction);
        void UpdateTransaction(TransactionDto transaction);
    }
}