using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ODataPrototype.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }

        #region Private Methods

        private static Tenant CreateTenant(int number, User user)
        {
            return new Tenant
            {
                Id = number,
                FirstName = "TF" + number,
                LastName = "TL" + number,
                Email = "TE" + number,
                UserId = user.Id
            };
        }

        private static Unit CreateUnit(int number, IEnumerable<Tenant> tenants)
        {
            var tenantId = GetTenantIdByUnitNumber(number, tenants);
            return new Unit
            {
                Id = number,
                Number = "N" + number,
                TenantId = tenantId
            };
        }

        private static int GetTenantIdByUnitNumber(int unitNumber, IEnumerable<Tenant> tenants)
        {
            if (unitNumber < 3)
                return 1;

            if (unitNumber == 3)
                return 2;

            if (unitNumber < 6)
                return 3;

            return 4;
        }

        private static User CreateUser(int number)
        {
            return new User
            {
                Id = number,
                FirstName = "UF" + number,
                LastName = "UL" + number,
                Email = "UE" + number
            };
        }

        #endregion

        #region Overrides of DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var users = Enumerable.Range(1, 5).Select(CreateUser);
            modelBuilder.Entity<User>().HasData(users);

            var tenants = Enumerable.Range(1, 5).Select(x => CreateTenant(x, users.Skip(x - 1).First()));
            modelBuilder.Entity<Tenant>().HasData(tenants);

            var units = Enumerable.Range(1, 8).Select(x => CreateUnit(x, tenants));
            modelBuilder.Entity<Unit>().HasData(units);
        }

        #endregion
    }
}
