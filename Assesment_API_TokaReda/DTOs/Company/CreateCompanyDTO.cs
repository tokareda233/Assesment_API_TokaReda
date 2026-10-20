using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assesment_API_TokaReda.DTOs.Company
{
    public class CreateCompanyDTO
    {
       
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public string? Website { get; set; }
        [Required]
        public string Location { get; set; }

        [ForeignKey("Employer")]
        public int EmployerId { get; set; }
    }
}
