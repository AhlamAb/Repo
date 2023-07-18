using CompnayWebsite_DataAccessLayer.Data.Repository.IRepository;
using CompnayWebsite_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompnayWebsite_DataAccessLayer.Data.Repository
{
    public class CompnayRepository : Repository<Company>, ICompnayRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public CompnayRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public void Update(int id, Company company)
        {
            var OldCompany = base.FirstOrDefault(c => c.CompanyID == id);
            if (OldCompany != null)
            {
                OldCompany.PhoneNumber = company.PhoneNumber;
                OldCompany.CompanyName = company.CompanyName;
                OldCompany.Email = company.Email;
                OldCompany.Size = company.Size;
                OldCompany.Sector = company.Sector;

            }
        }

        public IEnumerable<Company> ApplySorting(IEnumerable<Company> companies, string sortColumn, string sortColumnDirection)
        {
            switch (sortColumn)
            {
                case "CompanyID":
                    companies = sortColumnDirection == "asc"
                        ? companies.OrderBy(c => c.CompanyID)
                        : companies.OrderByDescending(c => c.CompanyID);
                    break;
                case "PhoneNumber":
                    companies = sortColumnDirection == "asc"
                        ? companies.OrderBy(c => c.PhoneNumber)
                        : companies.OrderByDescending(c => c.PhoneNumber);
                    break;
                case "Sector":
                    companies = sortColumnDirection == "asc"
                        ? companies.OrderBy(c => c.Sector)
                        : companies.OrderByDescending(c => c.Sector);
                    break;
                case "Size":
                    companies = sortColumnDirection == "asc"
                        ? companies.OrderBy(c => c.Size)
                        : companies.OrderByDescending(c => c.Size);
                    break;
                default:
                    // If the sort column is not recognized, return the companies without any sorting
                    break;
            }

            return companies;
        }
    }
}
