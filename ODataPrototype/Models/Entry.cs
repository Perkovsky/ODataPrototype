using System;
using System.Collections.Generic;

namespace ODataPrototype.Models
{
    public class Entry
	{
		public int EntryId { get; set; }
		public string Building { get; set; }
		public string Unit { get; set; }
		public DateTime? ExpirationDate { get; set; }
		public TimeSpan? ExpirationTime { get; set; }

		public IDictionary<string, object> EntryFields { get; set; }

		public IEnumerable<EntryTenantAccess> TenantAccesses { get; set; }
	}
}
