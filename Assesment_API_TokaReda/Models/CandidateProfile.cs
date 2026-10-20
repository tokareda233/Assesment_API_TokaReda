using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment_API_TokaReda.Models
{
    public class CandidateProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

        public string ?ResumeURL { get; set; }
        [Required]
        [MaxLength(500)]
        public string Skill {  get; set; }
        [Range(0,50)]
        public int YearsOfExperience {  get; set; }

        [ForeignKey("Candidate")]

        public int CadidateId { get; set; }
        public User ?Candidate { get; set; }

        public ICollection<Application> ?Applications { get; set; }
    }
}
