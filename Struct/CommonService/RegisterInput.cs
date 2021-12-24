using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OneFin.Struct.CommonService
{
    public class RegisterInput
    {

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        public string Email { get; set; }
        public string FullName { get; set; }

        public string UserRole { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
