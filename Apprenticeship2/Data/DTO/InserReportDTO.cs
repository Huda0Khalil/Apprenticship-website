using Apprenticeship2.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Apprenticeship2.Data.DTO
{
    public class InserReportDTO
    {
        [Required]
        [Display(Name = "Report Name")]
        public string reportName { get; set; }
        [Required]
        [Display(Name = "Report Description")]
        public string reportDescription { get; set; }
        [Required]
        [Display(Name = "Report Notes")]
        public string reportNotes { get; set; }

        public int assignmentId { get; set; }
        public int reportStatusId { get; set; }
        [Required]
        [Display(Name = "Files")]
        public List<IFormFile> upFiles { get; set; }
    }
}
