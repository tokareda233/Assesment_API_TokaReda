using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Assesment_API_TokaReda.Models
{
    [Index(nameof(Email),IsUnique =true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public CandidateProfile ?CandidateProfile {  get; set; }

        //employer
        public ICollection<Company> ?companies { get; set; }
    }
}
