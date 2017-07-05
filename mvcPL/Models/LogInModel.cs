using System.ComponentModel.DataAnnotations;

namespace mvcPL.Models
{
    public class LogInModel
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Please, enter your login")]
        public string LogIn { get; set; }

        [Display(Name = "Enter your password")]
        [Required(ErrorMessage = "Please, enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }
}