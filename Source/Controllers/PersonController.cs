﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using VirtualAgentAssessment.Domain.Models;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Models;

namespace VirtualAgentAssessment.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _personService;
        private IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
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
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreatePerson",model);
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new PersonViewModel();
            return View("EditPerson",model);
        }

        // POST: Person/Edit/5
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

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
    }
}