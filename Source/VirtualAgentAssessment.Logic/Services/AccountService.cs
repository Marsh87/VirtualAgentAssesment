using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Repositories.Interfaces;

namespace VirtualAgentAssessment.Logic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(
            IAccountRepository accountRepository,
            IMapper mapper
        )
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public List<AccountDto> GetAccountsFromPersonCode(int personCode)
        {
            var accounts = _accountRepository.GetAccountsForPerson(personCode).ToList();
            return _mapper.Map<List<Account>, List<AccountDto>>(accounts);
        }

        public void SaveAccount(AccountDto accountDto)
        {
            var account = _mapper.Map<AccountDto, Account>(accountDto);
            _accountRepository.SaveAccount(account);
        }
    }
}