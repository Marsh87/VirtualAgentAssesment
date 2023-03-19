using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using NUnit.Framework;
using PagedList;
using VirtualAgentAssessment.Controllers;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Logic.Models;
using VirtualAgentAssessment.Models;

namespace VirtualAgentAssessment.Tests.Controllers
{
    [TestFixture]
    public class TestPersonController
    {
        [Test]
        public void Index_GivenParameters_ShouldReturnViewWithModel()
        {
            // Arrange
            var searchString = "ABC";
            var page = 10;
            var searchType = "IdNumber";
            var personDtos = CreatePersonDtos();
            var personService = Substitute.For<IPersonService>();
            personService.GetPersonDtos(searchType, searchString).Returns(personDtos);
            var mapper = Substitute.For<IMapper>();
            var viewModelList = CreatePersonViewModels();
            mapper.Map<List<PersonDto>, List<PersonViewModel>>(personDtos).Returns(viewModelList);
            var accountService = Substitute.For<IAccountService>();
            var createPersonValidator = Substitute.For <IValidator<PersonViewModel>>();
            var editPersonValidator = Substitute.For <IValidator<EditPersonViewModel>>();
            var controller = new PersonController(personService,mapper,createPersonValidator,accountService,editPersonValidator);
            // Act
            var result = controller.Index(searchString, page, searchType) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("PersonList",result.ViewName);
        }

        private static List<PersonViewModel> CreatePersonViewModels()
        {
            var personViewModel = new PersonViewModel() { id_number = "ABC", name = "Max", surname = "Verstappen" };
            var viewModelList = new List<PersonViewModel>() { personViewModel };
            return viewModelList;
        }

        private static List<PersonDto> CreatePersonDtos()
        {
            var personDto = new PersonDto() { id_number = "ABC", name = "Max", surname = "Verstappen" };
            var personDtos = new List<PersonDto>() { personDto };
            return personDtos;
        }
    }
}