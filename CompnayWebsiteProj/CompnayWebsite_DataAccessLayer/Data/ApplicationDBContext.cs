using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CompnayWebsite_Models.Models;

namespace CompnayWebsite_DataAccessLayer.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Company> Company { get; set; }
        public DbSet<ComplaintsAndSuggestions> ComplaintsAndSuggestions { get; set; }
    }
}
