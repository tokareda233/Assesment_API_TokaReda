using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assesment_API_TokaReda.DTOs.Job
{
    public class CreateJobDTO
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [Range(0, 1000000)]
        public decimal Salary { get; set; }
        [Required]
        public string EmploymentType { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public string Status { get; set; }
       
        public int CompanyId { get; set; }
    }
}
