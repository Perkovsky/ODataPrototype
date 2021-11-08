namespace ODataPrototype.Models
{
    public class EntryTenantAccess
    {
        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public string Tenant { get; set; }
    }
}
