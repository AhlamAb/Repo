using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompnayWebsite_Models.Models
{
    public class ComplaintsAndSuggestions
    {
        [Key]
        public int ComplaintID { get; set; }


        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Title should contain only characters")]
        [MinLength(3, ErrorMessage = "Title should be at least 3 characters long")]
        [Required]
        public string Title { get; set; }


        [MinLength(10, ErrorMessage = "Description should be at least 10 characters long")]
        [Required]
        public string Description { get; set; }


        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        [Required]
        public CategoryOfComplaintsAndSuggestion CategoryOfComplaintsAndSuggestion { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }


    }
}
