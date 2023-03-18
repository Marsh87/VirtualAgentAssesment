using AutoMapper;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Logic.Models;
using VirtualAgentAssessment.Repositories.Interfaces;

namespace VirtualAgentAssessment.Logic.Services
{
    public class TransactionService: ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public TransactionDto GetTransaction(int code)
        {
            var transaction = _transactionRepository.GetTransactionFromCode(code);
            return _mapper.Map<Transaction, TransactionDto>(transaction);
        }

        public void SaveTransaction(TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<TransactionDto, Transaction>(transactionDto);
            _transactionRepository.SaveTransaction(transaction);
        }

        public void UpdateTransaction(TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<TransactionDto, Transaction>(transactionDto);
            _transactionRepository.UpdateTransaction(transaction);
        }
    }
}