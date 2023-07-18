using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompnayWebsite_Models.Models;

namespace CompnayWebsite_Models.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Company Name should contain only characters")]
        [MinLength(3, ErrorMessage = "Company Name should be at least 3 characters long")]
        [Required]
        public string CompanyName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }



        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Sector should contain only characters ")]
        [MinLength(3, ErrorMessage = "Sector should be at least 2 characters long")]
        [Required]
        public string Sector { get; set; }

        public virtual List<ComplaintsAndSuggestions> ComplaintsAndSuggestions { get; set; }

        [Required]
        public string Size { get; set; }

    }
}
