using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Logic.Models;
using VirtualAgentAssessment.Models;
using VirtualAssessment.Common.Interface;

namespace VirtualAgentAssessment.Controllers
{
    public class TransactionController : Controller
    {
        private IDateTimeProvider _dateTimeProvider;
        private IValidator<TransactionViewModel> _transactionValidator;
        private ITransactionService _transactionService;
        private IMapper _mapper;
        private IAccountService _accountService;

        public TransactionController(
            IDateTimeProvider dateTimeProvider, 
            IValidator<TransactionViewModel> transactionValidator, 
            ITransactionService transactionService,
            IMapper mapper,
            IAccountService accountService
            )
        {
            _dateTimeProvider = dateTimeProvider;
            _transactionValidator = transactionValidator;
            _transactionService = transactionService;
            _mapper = mapper;
            _accountService = accountService;
        }

        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transaction/Create
        public ActionResult Create(int accountCode)
        {
            var model = new TransactionViewModel();
            model.transaction_date = _dateTimeProvider.GetDateTimeToday();
            model.account_code = accountCode;
            return View("CreateTransaction",model);
        }

        // POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(TransactionViewModel transactionViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var validationResult = _transactionValidator.Validate(transactionViewModel);
                    if (validationResult.IsValid)
                    {
                        var transactionDto = _mapper.Map<TransactionViewModel, TransactionDto>(transactionViewModel);
                        _transactionService.SaveTransaction(transactionDto);
                        _accountService.ReCalculateAccountBalance(transactionViewModel.account_code);
                        return RedirectToAction("Edit", "Account", new { code = transactionViewModel.account_code });
                    }
                    SetFailuresOnModelState(validationResult);
                }
                return View("CreateTransaction",transactionViewModel);
            }
            catch(Exception exception)
            {
                return View("Error");
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int code)
        {
            var transaction = _transactionService.GetTransaction(code);
            var model = _mapper.Map<TransactionDto, TransactionViewModel>(transaction);
            return View("EditTransaction",model);
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(TransactionViewModel transactionViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var validationResult = _transactionValidator.Validate(transactionViewModel);
                    if (validationResult.IsValid)
                    {
                        var transactionDto = _mapper.Map<TransactionViewModel, TransactionDto>(transactionViewModel);
                        _transactionService.UpdateTransaction(transactionDto);
                        _accountService.ReCalculateAccountBalance(transactionViewModel.account_code);
                        return RedirectToAction("Edit", "Account", new { code = transactionViewModel.account_code });
                    }
                    SetFailuresOnModelState(validationResult);
                }
                return View("EditTransaction",transactionViewModel);
            }
            catch(Exception exception)
            {
                return View("Error");
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
