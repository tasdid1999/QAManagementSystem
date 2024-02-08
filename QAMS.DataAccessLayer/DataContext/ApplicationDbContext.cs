using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QAMS.DataAccessLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.DataAccessLayer.DataContext
{
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

          public DbSet<Question> questions { get; set; }

          public DbSet<Comment> comments { get; set; }

        }
}
