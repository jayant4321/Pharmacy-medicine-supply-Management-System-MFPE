using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyMedicineSupplyportal.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PharmacyMedicineDemandSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PharmacyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DemandCount = table.Column<int>(type: "int", nullable: false),
                    SupplyCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyMedicineDemandSupplies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyMedicineDemandSupplies");
        }
    }
}
