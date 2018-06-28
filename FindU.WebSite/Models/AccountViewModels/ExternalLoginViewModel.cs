using System.ComponentModel.DataAnnotations;

namespace FindU.WebSite.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
