using ClosedXML.Excel;
using CompnayWebsite_DataAccessLayer.Data.Repository.IRepository;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompnayWebsite.Controllers
{
   
    public class ExcelController : Controller
    {
        private readonly ICompnayRepository _compnayRepository;

        
        public ExcelController(ICompnayRepository compnayRepository)
        {
            _compnayRepository= compnayRepository;
        }

        public IActionResult ExportExcelFile()
        {
            var data = _compnayRepository.GetAll();
           using (var workbook = new XLWorkbook() )
            {
                var worksheet = workbook.Worksheets.Add("data");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value ="ID";
                worksheet.Cell(currentRow, 2).Value = "Name";
                worksheet.Cell(currentRow, 3).Value = "phone";
                worksheet.Cell(currentRow, 4).Value = "Email";
                worksheet.Cell(currentRow, 5).Value = "Sector";
                worksheet.Cell(currentRow, 6).Value = "size";

                foreach( var row in data )
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = row.CompanyID;
                    worksheet.Cell(currentRow, 2).Value = row.CompanyName;
                    worksheet.Cell(currentRow, 3).Value = row.PhoneNumber;
                    worksheet.Cell(currentRow, 4).Value = row.Email;
                    worksheet.Cell(currentRow, 5).Value = row.Sector;
                    worksheet.Cell(currentRow, 6).Value = row.Size;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" , "Companies.xlsx");
                }

            }
        }




    }
}
