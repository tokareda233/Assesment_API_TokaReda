using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assesment_API_TokaReda.DTOs.Job
{
    public class GetJobDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
       
        public string Description { get; set; }
       
        public string Location { get; set; }
       
        public decimal Salary { get; set; }
      
        public string EmploymentType { get; set; }
       
        public DateTime PostedDate { get; set; }
      
        public DateTime Deadline { get; set; }
        
        public string Status { get; set; }
     
        public int CompanyId { get; set; }
    }
}
