﻿namespace Core_Project.Areas.Writer.Models
{
    public class UserUpdateViewModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public string? PictureURL { get; set; }
        public IFormFile? Picture { get; set; }
    
    }
}
