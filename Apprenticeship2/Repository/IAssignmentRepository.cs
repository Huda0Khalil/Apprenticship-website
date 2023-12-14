using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public interface IAssignmentRepository
    {
        public List<Assignment> GetTrainingAssignments(int id);
        public Assignment GetAssignment(int id);
        public Task AddAssignment(InserAssignmentDTO inserAssignmentDTO);
        public UpdateAssignmentDTO AssignmentToUpdateAssignmentDTO(Assignment Ass);
        public void updateAssignmentRecord(UpdateAssignmentDTO upaDTO);
        public void DeletAssignment(int AID);
        public List<Assignment> GetStudentAssignments(string StudentID);
        public Assignment GetOneStudentAssignment(int assignmentID);
        public List<Assignment> GetTeamleaderAssignments(string leaderId);
        public int countAssignments(string StudentId);
        public int countFinishedAssignments(string StudentId);
        public int countCurrentAssignment(string StudentId);
        public List<Assignment> currentAssignments(string studentId);
        public Assignment getOneSupervisorAssignment(int AID);
    }
}
