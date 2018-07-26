﻿namespace FindU.Models.Identity
{
	public class UserRole
	{
		public string UserId { get; set; }
		public virtual User User { get; set; }
		public string RoleId { get; set; }
		public virtual Role Role { get; set; }
	}
}
