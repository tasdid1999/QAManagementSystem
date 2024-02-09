using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace QAMS.DataAccessLayer.DataContext
{
    
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [MinLength(3)]
        public string Name {  get; set; }

        [Required]
        [MinLength(3)]
        public string InstituteName { get; set; }

        public string? StudentId { get; set; }
        
    }

}
