using CompnayWebsite_DataAccessLayer.Data.Repository.IRepository;
using CompnayWebsite_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompnayWebsite_DataAccessLayer.Data.Repository
{
    public class ComplaintsAndSuggestionsRepository : Repository<ComplaintsAndSuggestions> , IComplaintsAndSuggestionsRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public ComplaintsAndSuggestionsRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public void Update(int id, ComplaintsAndSuggestions complaintsAndSuggestions)
        {
            var oldComplaints = base.FirstOrDefault(c => c.ComplaintID == id);
            if (oldComplaints != null)
            {
                oldComplaints.Title = complaintsAndSuggestions.Title;
                oldComplaints.Timestamp = complaintsAndSuggestions.Timestamp;
                oldComplaints.Description= complaintsAndSuggestions.Description;
            }
        }
    }
}
