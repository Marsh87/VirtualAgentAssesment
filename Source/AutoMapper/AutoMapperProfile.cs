using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Logic.Models;
using VirtualAgentAssessment.Models;

namespace VirtualAgentAssessment.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<PersonDto, PersonViewModel>().ReverseMap();
            CreateMap<PersonDto, DeletePersonViewModel>().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<AccountDto, AccountViewModel>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<TransactionDto, TransactionViewModel>().ReverseMap();
        }
    }
}