using VirtualAgentAssessment.Domain.Models;

namespace VirtualAgentAssessment.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction GetTransactionFromCode(int code);
        void SaveTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
    }
}