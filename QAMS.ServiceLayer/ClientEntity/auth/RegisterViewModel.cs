using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.ClientEntity.auth
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Field Can not be null")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field Can not be null")]
        [MinLength(3, ErrorMessage = "at least 3 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Can not be null")]
        [MinLength(3, ErrorMessage = "at least 3 character")]
        public string InstituteName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password and confirm password miss matched")]
        public string ConfirmPassword { get; set; }



        [Required(ErrorMessage = "Field Can not be null")]
        public string Role { get; set; }

    }
}
