using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataPrototype.Models
{
	public class Tenant
	{
		[Key]
		public int Id { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		public int UserId { get; set; }
		
		[ForeignKey(nameof(UserId))]
		public User User { get; set; }

		public IEnumerable<Unit> Units { get; set; }
	}
}
