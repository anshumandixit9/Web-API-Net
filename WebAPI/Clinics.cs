using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class Clinics
    {
        
        public int id { get; set; }
        [Key]
        [Required]
        public string ClinicName { get; set; } = "Not Available";
        public string Location { get; set; } = "Not Available";
    }
}
