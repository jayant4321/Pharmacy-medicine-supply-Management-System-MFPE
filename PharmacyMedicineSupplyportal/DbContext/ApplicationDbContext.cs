using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmacyMedicineSupplyportal.Model;

namespace PharmacyMedicineSupplyportal.DbContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PharmacyMedicineDemandSupply> PharmacyMedicineDemandSupplies { get; set; }
    }
}
