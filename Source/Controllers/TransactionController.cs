using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualAgentAssessment.Models;
using VirtualAssessment.Common.Interface;

namespace VirtualAgentAssessment.Controllers
{
    public class TransactionController : Controller
    {
        private IDateTimeProvider _dateTimeProvider;

        public TransactionController(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
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
            model.transaction_date = _dateTimeProvider.GetDateTimeNow();
            model.account_code = accountCode;
            return View("CreateTransaction");
        }

        // POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(TransactionViewModel transactionViewModel)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int code)
        {
            return View();
        }

        // POST: Transaction/Edit/5
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
    }
}
