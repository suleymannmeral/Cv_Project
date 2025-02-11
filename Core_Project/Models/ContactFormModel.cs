using System.ComponentModel.DataAnnotations;

namespace Core_Project.Models
{
    public class ContactFormModel
    {
            [Required]
            public string? Name { get; set; }

            [Required, EmailAddress]
            public string? Mail { get; set; }

            [Required]
            public string? Content { get; set; }
        

    }
}
