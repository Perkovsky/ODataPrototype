using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataPrototype.Models
{
	public class Unit
	{
		[Key]
		public int Id { get; set; }
		
		public string Number { get; set; }

		public int TenantId { get; set; }
		
		[ForeignKey(nameof(TenantId))]
		public Tenant Tenant { get; set; }
	}
}
