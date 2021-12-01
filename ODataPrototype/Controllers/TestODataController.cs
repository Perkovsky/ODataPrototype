using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ODataPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ODataPrototype.Controllers
{
    [Route("odata")]
    [ApiVersion("1.0")]
    public class TestODataController : ODataController
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        [EnableQuery]
        public IQueryable<Entry> Get()
        {
            var list = new List<Entry>
            {
                new Entry
                {
                    EntryId = 1,
                    Building = "Building #1",
                    Unit = "Unit #1",
                    ExpirationDate = DateTime.Now.AddDays(1),
                    TenantInfo = new TenantInfo { Name = "Ivan", Age = 22, CellPhone = "929-444-22-55" },
                    EntryFields = new Dictionary<string, object>
                    {
                        { "field_467", "field has ID = 467-1" },
                        { "field_468", "field has ID = 468-1" },
                        { "field_469", "field has ID = 469-1" },
                    },
                    TenantAccesses = new List<EntryTenantAccess>
                    {
                        new EntryTenantAccess { CanDelete = true, CanRead = true, CanUpdate = true, Tenant = "Admin" },
                        new EntryTenantAccess { CanDelete = false, CanRead = true, CanUpdate = true, Tenant = "Manager #1" },
                        new EntryTenantAccess { CanDelete = false, CanRead = true, CanUpdate = false, Tenant = "Tenant #1"},
                    }
                },
                new Entry
                {
                    EntryId = 2,
                    Building = "Building #1",
                    Unit = "Unit #2",
                    ExpirationDate = DateTime.Now.AddDays(2),
                    TenantInfo = new TenantInfo { Name = "Oleg", Age = 44, CellPhone = "929-33-11-53" },
                    EntryFields = new Dictionary<string, object>
                    {
                        { "field_467", "field has ID = 467-2" },
                        { "field_468", "field has ID = 468-2" },
                        { "field_469", "field has ID = 469-2" },
                    },
                    TenantAccesses = new List<EntryTenantAccess>
                    {
                        new EntryTenantAccess { CanDelete = true, CanRead = true, CanUpdate = true, Tenant = "Admin" },
                    }
                },
                new Entry
                {
                    EntryId = 3,
                    Building = "Building #1",
                    Unit = "Unit #3",
                    ExpirationDate = DateTime.Now.AddDays(2),
                    TenantInfo = new TenantInfo { Name = "Ivan", Age = 28, CellPhone = "929-424-62-75" },
                    EntryFields = new Dictionary<string, object>
                    {
                        { "field_467", "field has ID = 467-3" },
                        { "field_468", "field has ID = 468-3" },
                        { "field_469", "field has ID = 469-3" },
                    },
                    TenantAccesses = new List<EntryTenantAccess>
                    {
                        new EntryTenantAccess { CanDelete = true, CanRead = true, CanUpdate = true, Tenant = "Admin" },
                        new EntryTenantAccess { CanDelete = false, CanRead = true, CanUpdate = false, Tenant = "Tenant #2"},
                    }
                },
                new Entry
                {
                    EntryId = 4,
                    Building = "Building #1",
                    Unit = "Unit #4",
                    ExpirationDate = DateTime.Now.AddDays(5),
                    TenantInfo = new TenantInfo { Name = "Andrew", Age = 18, CellPhone = "929-567-32-24" },
                    EntryFields = new Dictionary<string, object>
                    {
                        { "field_467", "field has ID = 467-4" },
                        { "field_468", "field has ID = 468-4" },
                        { "field_469", "field has ID = 469-4" },
                    },
                    TenantAccesses = new List<EntryTenantAccess>
                    {
                        new EntryTenantAccess { CanDelete = true, CanRead = true, CanUpdate = true, Tenant = "Admin" },
                        new EntryTenantAccess { CanDelete = false, CanRead = true, CanUpdate = true, Tenant = "Manager #2" },
                        new EntryTenantAccess { CanDelete = false, CanRead = true, CanUpdate = false, Tenant = "Tenant #3"},
                    }
                }
            };

            return list.AsQueryable();
        }
    }
}
