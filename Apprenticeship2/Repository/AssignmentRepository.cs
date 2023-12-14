using Apprenticeship2.Data;
using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Apprenticeship2.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        ApplicationDbContext context;
        IAttatcheFileRepository attatcheFileRepository;
        public AssignmentRepository(ApplicationDbContext context, IAttatcheFileRepository attatcheFileRepository)
        {
            this.context = context;
            this.attatcheFileRepository = attatcheFileRepository;
        }
        public List<Assignment> GetTrainingAssignments(int id)
        {
            var Assign = context.assignments.Include(x => x.training).Where(x => x.trainingId == id).ToList();
            return Assign;
        }
        public Assignment GetAssignment(int id)
        {
            var Ass= context.assignments.Include(x => x.assignmentObjectives).Include(x => x.fileAttatchments).Where(x => x.AssignmentId == id).SingleOrDefault();
            return Ass;
        }
        public UpdateAssignmentDTO AssignmentToUpdateAssignmentDTO(Assignment Ass)
        {
            UpdateAssignmentDTO updateAssignmentDTO = new UpdateAssignmentDTO();
            updateAssignmentDTO.trainingId = Ass.trainingId;
            updateAssignmentDTO.AssignmentId = Ass.AssignmentId;
            updateAssignmentDTO.AssignmentDescription = Ass.AssignmentDescription;
            updateAssignmentDTO.assignmentTitle = Ass.assignmentTitle;
            updateAssignmentDTO.assignmentNotes = Ass.assignmentNotes;
            updateAssignmentDTO.startDate = Ass.startDate;
            updateAssignmentDTO.endDate = Ass.endDate;
            updateAssignmentDTO.objectiveIDs = new List<int>();
            foreach(var AO in Ass.assignmentObjectives)
            {
                updateAssignmentDTO.objectiveIDs.Add(AO.objectiveId);
            }
            //var files = context.fileAttatchments.Where(x => x.AssignmentId ==  Ass.AssignmentId).ToList();

            return updateAssignmentDTO;
        }
        public async void updateAssignmentRecord(UpdateAssignmentDTO upaDTO)
        {
            Assignment oldAssignment = GetAssignment(upaDTO.AssignmentId);
            oldAssignment.assignmentTitle = upaDTO.assignmentTitle;
            oldAssignment.assignmentNotes = upaDTO.assignmentNotes;
            oldAssignment.assignmentNotes = upaDTO.assignmentNotes;
            oldAssignment.startDate = upaDTO.startDate;
            oldAssignment.endDate = upaDTO.endDate;
            context.assignments.Update(oldAssignment);
            context.SaveChanges();
            var AssObj = context.assignmentObjectives.Where(x => x.assignmentId == upaDTO.AssignmentId).ToList();
            foreach(var AO in AssObj)
            {
                context.assignmentObjectives.Remove(AO);
            }
            context.SaveChanges();
            foreach(var OID in upaDTO.objectiveIDs)
            {
                AssignmentObjectives assignmentObjectives = new AssignmentObjectives();
                assignmentObjectives.objectiveId = OID;
                assignmentObjectives.assignmentId = upaDTO.AssignmentId;
                context.assignmentObjectives.Add(assignmentObjectives);
            }
            context.SaveChanges();
            
            if(upaDTO.upFiles != null)
            {
                 attatcheFileRepository.AddFile(upaDTO.upFiles, upaDTO.AssignmentId);

            }
        }
        public void DeletAssignment(int AID)
        {
            Assignment assignment = GetAssignment(AID);

            var assignmentObjectives = context.assignmentObjectives.Where(x => x.assignmentId == AID).ToList();
            foreach(var AO in assignmentObjectives)
            {
                context.assignmentObjectives.Remove(AO);
            }
            
            context.SaveChanges();
            foreach(var f in assignment.fileAttatchments)
            {
                attatcheFileRepository.deleteFile(f.assignmentFilesId);
            }
           
            context.assignments.Remove(assignment);
            context.SaveChanges();
        }
        public async Task AddAssignment(InserAssignmentDTO inserAssignmentDTO)
        {      
            Assignment assignment = new Assignment();
            assignment.assignmentTitle = inserAssignmentDTO.assignmentTitle;
            assignment.AssignmentDescription = inserAssignmentDTO.AssignmentDescription;
            assignment.assignmentNotes = inserAssignmentDTO.assignmentNotes;
            assignment.startDate = inserAssignmentDTO.startDate;
            assignment.endDate = inserAssignmentDTO.endDate;
            assignment.trainingId = inserAssignmentDTO.trainingID;
              
            context.assignments.Add(assignment);
            context.SaveChanges();
            attatcheFileRepository.AddFile(inserAssignmentDTO.upFiles,assignment.AssignmentId);
            
            foreach (var OID in inserAssignmentDTO.objectives)
            {
                AssignmentObjectives assignmentObjectives = new AssignmentObjectives();
                assignmentObjectives.assignmentId = assignment.AssignmentId;
                assignmentObjectives.objectiveId = OID;
                context.assignmentObjectives.Add(assignmentObjectives);
                context.SaveChanges();
            }
           
            
        }
        public List<Assignment> GetStudentAssignments(string StudentID)
        { 
            return context.assignments.Include(A =>A.training).Include(A => A.assignmentObjectives).ThenInclude(AO => AO.objective).Where( x => x.training.studentId == StudentID ).ToList();
        }
        public List<Assignment> GetTeamleaderAssignments(string leaderId)
        {
            return context.assignments.Include(A => A.training).Include(A => A.assignmentObjectives).ThenInclude(AO => AO.objective).Where(x => x.training.teamLeaderId == leaderId).ToList();
        }
        public Assignment GetOneStudentAssignment(int assignmentID)
        {
           return context.assignments.Include( x => x.fileAttatchments).Include(x => x.assignmentObjectives).ThenInclude(x=> x.objective).Where(x => x.AssignmentId == assignmentID).SingleOrDefault();
        }
        public int countAssignments(string StudentId)
        {
            return context.assignments.Include(x => x.training).Where(x => x.training.studentId == StudentId).Count();
        }
        public int countFinishedAssignments(string StudentId)
        {
            DateTime currentDate = DateTime.Now;
            return context.assignments.Include(x => x.training).Where(x => x.training.studentId == StudentId && x.endDate < currentDate).Count();
        }
        public int countCurrentAssignment(string StudentId)
        {
            DateTime currentDate = DateTime.Now;
            return context.assignments.Include(x => x.training).Where(x => x.training.studentId == StudentId && x.startDate < currentDate && x.endDate > currentDate).Count();
        }
        public List<Assignment> currentAssignments(string studentId)
        {
            DateTime currentDate = DateTime.Now;
            return context.assignments.Include(x => x.training).Where(x => x.training.studentId ==  studentId && x.startDate < currentDate && x.endDate > currentDate).ToList();
        }
        public Assignment getOneSupervisorAssignment(int AID)
        {
           return context.assignments.Include(x => x.assignmentObjectives).ThenInclude(x => x.objective).Include(x => x.training).Include(x => x.fileAttatchments).Where(x => x.AssignmentId == AID).SingleOrDefault();
        }


    }
}
