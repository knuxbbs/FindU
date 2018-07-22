using Microsoft.AspNetCore.Identity;
using System;

namespace FindU.Infra.Data.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
		public DateTime CreatedOn { get; set; }
	}
}
