using System.ComponentModel.DataAnnotations;

namespace Core_Project.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {

        [Required(ErrorMessage = "Please Enter The Name")]
        public  string? Name { get; set; }
        [Required(ErrorMessage = "Please Enter The Surname")]
        public required string Surname { get; set; }

        [Required(ErrorMessage ="Please Enter The Username")]
        public required string  UserName { get; set; }
        [Required(ErrorMessage = "Please Enter The Username")]
        public required string Sumey { get; set; }

        [Required(ErrorMessage = "Please Enter The Password")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Please Enter The Password Again")]
        [Compare("Password",ErrorMessage ="Passwords don't match")]
        public required string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter The Mail Adress")]
        public required string Mail { get; set; }
    }
}
