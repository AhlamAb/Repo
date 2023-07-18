using Microsoft.AspNetCore.Mvc;
using CompnayWebsite_DataAccessLayer.Data.Repository.IRepository;
using System.Collections;
using CompnayWebsite_Models.Models;
using System.Collections.Generic;
using System.Linq;
using CompnayWebsite_DataAccessLayer.Data;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Xml.Linq;

namespace CompnayWebsite.Controllers
{
    
    public class CompanyController : Controller
    {
        private readonly ICompnayRepository _compnayRepository;

        public CompanyController(ICompnayRepository compnayRepository)
        {
                _compnayRepository= compnayRepository;
        }

        public IActionResult Index()
        {
            List<Company> companies = _compnayRepository.GetAll().ToList();
            return View(companies);

        }

       
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }
            else
            {
                try
                {
                    _compnayRepository.Add(company);
                    _compnayRepository.Save();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(company);
                }
            }
        }

        //Get - Edit
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var company = _compnayRepository.FirstOrDefault(c => c.CompanyID == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }
        // Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }
            else
            {
                try
                {
                    var OldCompany = _compnayRepository.FirstOrDefault(c => c.CompanyID == id);
                    if (OldCompany == null)
                    {
                        return NotFound();
                    }

                   _compnayRepository.Update(id, company);
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(company);
                }
            }
        }




    }
}
