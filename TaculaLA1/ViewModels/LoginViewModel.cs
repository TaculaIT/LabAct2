using System.ComponentModel.DataAnnotations;


namespace TaculaLA1.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name ="User Name")]
        [Required(ErrorMessage ="a username is required")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "a password is required")]
        public string? ConfirmPassword { get; set; }
       
    }
}
