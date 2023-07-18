using CompnayWebsite_DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CompnayWebsite_DataAccessLayer.Data.Repository.IRepository;
using System.Linq;
using CompnayWebsite_Models.Models;
using Syncfusion.EJ2.Schedule;
using Microsoft.AspNetCore.Authorization;

namespace CompnayWebsite.Controllers
{

    public class ReportController : Controller
    {
        private readonly ICompnayRepository _compnayRepository;
        public ReportController(ICompnayRepository compnayRepository)
        {
            _compnayRepository= compnayRepository;
        }

        public IActionResult ShowReport()
        {
            ViewBag.sizeGroups = _compnayRepository.GetAll()
              .GroupBy(c => c.Size)
              .Select(g => new { Size = g.Key, Count = g.Count() })
              .ToList();

            ViewBag.sectorGroups = _compnayRepository.GetAll(c =>c.Sector != "n/a")
               .GroupBy(c => c.Sector)
              .Select(g => new { Sector = g.Key, Count = g.Count() })
              .ToList();


            return View();
        }

       

    }
}
