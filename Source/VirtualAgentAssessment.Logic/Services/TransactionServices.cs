using AutoMapper;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Repositories.Interfaces;

namespace VirtualAgentAssessment.Logic.Services
{
    public class TransactionServices: ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionServices(ITransactionRepository transactionRepository, IMapper mapper)
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