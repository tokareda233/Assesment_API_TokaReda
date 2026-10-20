using Assesment_API_TokaReda.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assesment_API_TokaReda.DTOs.Application
{
    public class CreateApplicationDTO
    {
       
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required]
        public string Status { get; set; }
        [MaxLength(2000)]
        public string? CoverLetter { get; set; }

      
        public int CandidateProfileId { get; set; }
      
        public int JobId { get; set; }
    }
}
