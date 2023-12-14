using System.ComponentModel.DataAnnotations;

namespace Apprenticeship2.Data.DTO
{
    public class InserAssignmentDTO
    {
        [Required]
       public int trainingID { get; set; }
        [Required]
        [Display(Name = "Assignment Title")]
        public string assignmentTitle { get; set; }
        [Required]
        [Display(Name = "Assignment Description")]
        public string AssignmentDescription { get; set; }
        [Required]
        [Display(Name = "Assignment Notes")]
        public string assignmentNotes { get; set; }
        [Required]
        [Display(Name = "Strt Date")]
        public DateTime startDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }
        [Required]
        [Display(Name = "Objectives")]
        public List<int> objectives { get; set; }
        [Required]
        [Display(Name = "Files")]
        public IEnumerable<IFormFile> upFiles { get; set; }
    }
}
