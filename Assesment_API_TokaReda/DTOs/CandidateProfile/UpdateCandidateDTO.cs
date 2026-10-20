using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assesment_API_TokaReda.DTOs.CandidateProfile
{
    public class UpdateCandidateDTO
    {
        [Required]
        [Phone]
        public string Phone { get; set; }

        public string? ResumeURL { get; set; }
        [Required]
        [MaxLength(500)]
        public string Skill { get; set; }
        [Range(0, 50)]
        public int YearsOfExperience { get; set; }

        [ForeignKey("Candidate")]

        public int CadidateId { get; set; }
    }
}
