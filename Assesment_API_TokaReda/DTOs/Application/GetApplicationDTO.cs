using Assesment_API_TokaReda.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assesment_API_TokaReda.DTOs.Application
{
    public class GetApplicationDTO
    {
        public int Id { get; set; }
      
        public DateTime ApplicationDate { get; set; }
     
        public string Status { get; set; }
       
        public string? CoverLetter { get; set; }

        public int CandidateProfileId { get; set; }
       
        public int JobId { get; set; }
    }
}
