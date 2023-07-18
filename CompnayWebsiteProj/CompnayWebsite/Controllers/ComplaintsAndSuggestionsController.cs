using CompnayWebsite_DataAccessLayer.Data;
using CompnayWebsite_DataAccessLayer.Data.Repository.IRepository;
using CompnayWebsite_Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CompnayWebsite.Controllers
{
    public class ComplaintsAndSuggestionsController : Controller
    {
        // لازم اعمله repo
        private readonly IComplaintsAndSuggestionsRepository _complaintsAndSuggestionsRepository;
        private readonly ICompnayRepository _compnayRepository;
        public ComplaintsAndSuggestionsController(IComplaintsAndSuggestionsRepository complaintsAndSuggestionsRepository
         , ICompnayRepository compnayRepository )
        {
            _complaintsAndSuggestionsRepository = complaintsAndSuggestionsRepository;
            _compnayRepository = compnayRepository;
        }
        //Get All
        public IActionResult Index()
        {
            var complaintsAndSuggestions = _complaintsAndSuggestionsRepository.GetAll(null , "Company");
            return View(complaintsAndSuggestions);
        }


        //Get one
        public IActionResult GetByID(int id)
        {
            var complaintAndSuggestion = _complaintsAndSuggestionsRepository.FirstOrDefault(null, "Company");
            return View(complaintAndSuggestion);
        }

        //Get - create
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewBag.companies = _compnayRepository.GetAll();
            return View();
        }

        //Post - create
          [AllowAnonymous]
          [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ComplaintsAndSuggestions complaintsAndSuggestions)
        {
            ViewBag.companies = _compnayRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return View(complaintsAndSuggestions);
            }
            else
            {
                try
                {
                    _complaintsAndSuggestionsRepository.Add(complaintsAndSuggestions);
                    _complaintsAndSuggestionsRepository.Save();
                    return View("ThankYou");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(complaintsAndSuggestions);
                }
            }
        }
    }
}
