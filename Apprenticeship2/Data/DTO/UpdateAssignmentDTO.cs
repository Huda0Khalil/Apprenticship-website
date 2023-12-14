using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Data.DTO
{
    public class UpdateAssignmentDTO
    {
        public int trainingId {  get; set; } 
        public int AssignmentId { get; set; }
        public string assignmentTitle { get; set; }
        public string AssignmentDescription { get; set; }
        public string assignmentNotes { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<int> objectiveIDs { get; set; }
        public IEnumerable<IFormFile> upFiles { get; set; }
        public List<int> fileRemovedIDs { get; set; }
    }
}
