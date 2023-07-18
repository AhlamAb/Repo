using CompnayWebsite_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompnayWebsite_DataAccessLayer.Data.Repository.IRepository
{
    public interface IComplaintsAndSuggestionsRepository : IRepository<ComplaintsAndSuggestions>
    {
        void Update(int id, ComplaintsAndSuggestions complaintsAndSuggestions);
    }
}
