using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assesment_API_TokaReda.DTOs.Company
{
    public class GetCompanyDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public string Description { get; set; }

        public string? Website { get; set; }
       
        public string Location { get; set; }

     
        public int EmployerId { get; set; }
    }
}
