using System.ComponentModel.DataAnnotations;

namespace QAMS.ServiceLayer.ClientEntity.auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "email must required")]
        [EmailAddress(ErrorMessage = "Email Address must contain @")]
        public string Email { get; set; }

        [Required(ErrorMessage = "password must required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "length should be 3 at least")]
        public string Password { get; set; }
    }
}
