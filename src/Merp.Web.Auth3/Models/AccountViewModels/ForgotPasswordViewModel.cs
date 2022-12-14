using System.ComponentModel.DataAnnotations;

namespace Merp.Web.Auth.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
