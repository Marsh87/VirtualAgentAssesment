using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Models;

namespace VirtualAgentAssessment.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IValidator<AccountViewModel> _createAccountValidator;
        private readonly IValidator<CloseAccountViewModel> _closeAccountValidator;

        public AccountController(
            IAccountService accountService,
            IMapper mapper,
            IValidator<AccountViewModel> createAccountValidator, 
            IValidator<CloseAccountViewModel> closeAccountValidator
            )
        {
            _accountService = accountService;
            _mapper = mapper;
            _createAccountValidator = createAccountValidator;
            _closeAccountValidator = closeAccountValidator;
        }

        public ActionResult Index()
        {
            return View();
        }


        // GET: Account/Create
        public ActionResult Create(int personCode)
        {
            var accountViewModel = new AccountViewModel();
            accountViewModel.person_code = personCode;
            return View("CreateAccount", accountViewModel);
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(AccountViewModel accountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    accountViewModel.IsActive = true;
                    var validationResult = _createAccountValidator.Validate(accountViewModel);
                    if (validationResult.IsValid)
                    {
                        var accountDto = _mapper.Map<AccountViewModel, AccountDto>(accountViewModel);
                        _accountService.SaveAccount(accountDto);
                        return RedirectToAction("Edit", "Person", new { code = accountViewModel.person_code });
                    }

                    SetFailuresOnModelState(validationResult);
                }

                return View("CreateAccount", accountViewModel);
            }
            catch (Exception exception)
            {
                return View("Error");
            }
        }

        // GET: Account/Edit/5
        public ActionResult CloseAccount(int code)
        {
            var account = _accountService.GetAccountFromCode(code);
            var model = _mapper.Map<AccountDto,CloseAccountViewModel>(account);
            return View("CloseAccount",model);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult CloseAccount(CloseAccountViewModel closeAccountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var validationResult = _closeAccountValidator.Validate(closeAccountViewModel);
                    if (validationResult.IsValid)
                    {
                        _accountService.SetAccountStatus(closeAccountViewModel.code, false);
                        return RedirectToAction("Edit", "Person", new { code = closeAccountViewModel.person_code });
                    }
                    SetFailuresOnModelState(validationResult);
                }
                return View("CloseAccount",closeAccountViewModel);
            }
            catch (Exception exception)
            {
                return View("Error");
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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