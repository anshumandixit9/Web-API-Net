using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class Medicines
    {
        public string ClinicName { get; set; }
        [Key]
        [Required]
        public string MedicineName { get; set; }
        public int id { get; set; }
        public int AvailableStock { get; set; }
    }
}
