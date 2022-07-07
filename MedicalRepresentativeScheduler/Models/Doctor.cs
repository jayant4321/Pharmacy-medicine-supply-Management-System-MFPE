namespace MedicalRepresentativeScheduler.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long ContactNumber { get; set; }

        public string Slot { get; set; }
        public string TreatingAlignment { get; set; }

    }
}
