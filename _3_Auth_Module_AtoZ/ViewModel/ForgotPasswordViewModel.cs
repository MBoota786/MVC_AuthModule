using System.ComponentModel.DataAnnotations;

namespace _3_Auth_Module_AtoZ.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
