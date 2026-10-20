using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assesment_API_TokaReda.DTOs.CandidateProfile
{
    public class GetCandidateProfileDTO
    {
        public int Id { get; set; }
       
        public string Phone { get; set; }

        public string? ResumeURL { get; set; }
       
        public string Skill { get; set; }
      
        public int YearsOfExperience { get; set; }

    
        public int CadidateId { get; set; }
    }
}
