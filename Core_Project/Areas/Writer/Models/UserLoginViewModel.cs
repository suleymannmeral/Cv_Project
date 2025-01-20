using System.ComponentModel.DataAnnotations;

namespace Core_Project.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Username")]
        [Required(ErrorMessage ="Enter The Username")]
        public  string? Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter The Password")]
        public  string? Password { get; set; }
        public  int AccessFailedCount{ get; set; }
       
    }
}
