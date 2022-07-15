namespace PharmacyMedicineSupplyportal.Model
{
    public class PharmacyMedicineDemandSupply
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string PharmacyName { get; set; }
        public int DemandCount { get; set; }
        public int SupplyCount { get; set; }

    }
}
