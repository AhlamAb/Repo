using CompnayWebsite_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompnayWebsite_DataAccessLayer.Data.Repository.IRepository
{
    public interface ICompnayRepository : IRepository<Company>
    {
        void Update(int id, Company company);

        IEnumerable<Company> ApplySorting(IEnumerable<Company> companies, string sortColumn, string sortColumnDirection);

    }
}
