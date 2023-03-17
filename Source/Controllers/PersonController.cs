using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using PagedList;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Logic.Models;
using VirtualAgentAssessment.Models;

namespace VirtualAgentAssessment.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _personService;
        private IMapper _mapper;
        private IValidator<PersonViewModel> _createPersonValidator;
        private IValidator<EditPersonViewModel> _editPersonValidator;
        private IAccountService _accountService;

        public PersonController(
            IPersonService personService, 
            IMapper mapper, 
            IValidator<PersonViewModel> createPersonValidator, 
            IAccountService accountService, 
            IValidator<EditPersonViewModel> editPersonValidator
            )
        {
            _personService = personService;
            _mapper = mapper;
            _createPersonValidator = createPersonValidator;
            _accountService = accountService;
            _editPersonValidator = editPersonValidator;
        }

        // GET: Person
        public ActionResult Index(string searchString, int? page, string searchType)
        {
            if (searchString != null)
            {
                ViewBag.SearchString = searchString;
            }

            if(searchType != null)
            {
                ViewBag.SearchCategory = searchType;
            }
            
            ViewBag.SearchCategoryList = new SelectList(GetSearchCategories(),"Value","Text");
            var persons = _personService.GetPersonDtos(searchType, searchString);
            var model = _mapper.Map<List<PersonDto>, List<PersonViewModel>>(persons);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View("PersonList", model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View("CreatePerson");
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var validationResult = _createPersonValidator.Validate(model);
                    if (validationResult.IsValid)
                    {
                        var personDto = _mapper.Map<PersonViewModel, PersonDto>(model);
                        _personService.SavePerson(personDto);
                        return RedirectToAction("Index");   
                    }
                    SetFailuresOnModelState(validationResult);
                }
                return View("CreatePerson",model);
            }
            catch(Exception exception)
            {
                return View("Error");
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int code)
        {
            var person = _personService.GetPersonDto(code);
            var model = _mapper.Map<PersonDto, EditPersonViewModel>(person);
            return View("EditPerson",model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(EditPersonViewModel model)
        {
            try
            {
                var accounts = _accountService.GetAccountsFromPersonCode(model.code);
                var accountViewModel = _mapper.Map<List<AccountDto>, List<AccountViewModel>>(accounts);
                model.Accounts = accountViewModel;
                if (ModelState.IsValid)
                {
                    var validationResult = _editPersonValidator.Validate(model);
                    if (validationResult.IsValid)
                    {
                        var personDto = _mapper.Map<EditPersonViewModel, PersonDto>(model);
                        _personService.EditPerson(personDto);
                        return RedirectToAction("Index");   
                    }
                    SetFailuresOnModelState(validationResult);
                }
                return View("EditPerson",model);
            }
            catch(Exception exception)
            {
                return View("Error");
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int code)
        {
            var person = _personService.GetPersonDto(code);
            var model = _mapper.Map<PersonDto, DeletePersonViewModel>(person);
            return View("DeletePerson",model);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int code)
        {
            try
            {
                var person = _personService.GetPersonDto(code);
                var model = _mapper.Map<PersonDto, DeletePersonViewModel>(person);
                if (person.Accounts.Any(x => x.IsActive))
                {
                    ModelState.AddModelError(String.Empty, "Person still has an Account that is active");   
                }

                if (ModelState.IsValid)
                {
                    _personService.DeletePerson(person.code);
                    return RedirectToAction("Index");
                }
                return View("DeletePerson", model);
            }
            catch(Exception exception)
            {
                return View("Error");
            }
        }

        private static List<SelectListItem> GetSearchCategories()
        {
            return new List<SelectListItem>
            {
                 new SelectListItem() { Text = "-- Search Category --", Value = "-- Search Category --" },
                new SelectListItem() { Text = "Id Number", Value = "Id Number" },
                new SelectListItem() { Text = "Account Number", Value = "Account Number" },
                new SelectListItem() { Text = "Surname", Value = "Surname" }
            };
        }
        
        private void SetFailuresOnModelState(ValidationResult validationResult)
        {
            ModelState.Clear();
            foreach (var validationFailure in validationResult.Errors)
            {
                ModelState.AddModelError("", validationFailure.ErrorMessage);
            }
        }
    }
}
