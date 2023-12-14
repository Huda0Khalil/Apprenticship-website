using Apprenticeship2.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Apprenticeship2.Data.DTO
{
    public class InsertTrainingDTO
    {
        [Required]
        [Display(Name = "Student")]
        public string studentId { get; set; }
        [Required]
        [Display(Name = "University Supervisor")]
        public string supervisorId { get; set; }
        [Required]
        [Display(Name = "Team Leader")]
        public string teamLeaderId { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }
        [Required]
        [Display(Name = "Objectives")]
        public List<int> objectiveIDs{ get; set; }
    }
}
