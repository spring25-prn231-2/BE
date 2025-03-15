using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.BusinessService.BusinessModels
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
    public class RegisterRequestModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string FullName { get; set; } = null!;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
    public class LoginResponseModel
    { 

    }
}
