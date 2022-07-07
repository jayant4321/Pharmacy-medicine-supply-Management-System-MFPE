using Microsoft.EntityFrameworkCore;
using PharmacyMedicineSupplyportal.Model;

namespace PharmacyMedicineSupplyportal.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PharmacyMedicineDemandSupply> PharmacyMedicineDemandSupplies { get; set; }
    }
}
