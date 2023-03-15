using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Models;

namespace VirtualAgentAssessment.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, PersonViewModel>();
        }
    }
}