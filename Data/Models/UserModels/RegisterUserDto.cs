using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Models.UserModels
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "Username is too long.")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{5,49}$", ErrorMessage = "Username should have at least 6 characters, contain a to z and/or numbers and/or _")]
        public string UserName { get; set; }
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*#?&^\._-])(?!.*\s).{8,}$", ErrorMessage = "Password must Contain 8 Characters, include atleast one uppercase, one lowercase, one number and one special case character")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again.")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^[0][1-9]{2}[0-9]{7}$", ErrorMessage = "You are not typing a phone number. If you don't have one, leave it empty.")]
        public string? PhoneNumber { get; set; }
    }
}
