using Apprenticeship2.Data;
using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship2.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        ApplicationDbContext context;
        public TrainingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void createTraining(InsertTrainingDTO trainingDTO)
        {
            Training training = new Training();
            training.studentId = trainingDTO.studentId;
            training.supervisorId = trainingDTO.supervisorId;
            training.teamLeaderId = trainingDTO.teamLeaderId;
            training.startDate = trainingDTO.startDate;
            training.endDate = trainingDTO.endDate;
            context.trainings.Add(training);
            context.SaveChanges();
            foreach (var OID in trainingDTO.objectiveIDs)
            {
                TrainingObjectives trainingObjectives = new TrainingObjectives();
                trainingObjectives.objectiveId = OID;
                trainingObjectives.trainingId = training.TrainingId;
                context.trainingObjectives.Add(trainingObjectives);

            }
            context.SaveChanges();
        }
        public List<Training> GetAllTraining()
        {
            return context.trainings.Include(x => x.student).Include(x => x.supervisor).Include(x => x.teamLeader).ToList();
        }
        public Training GetOneTraining(int trainingId)
        {
            return context.trainings.Include(T => T.trainingObjectives).Include(x => x.student).Include(x => x.teamLeader).Where(x => x.TrainingId == trainingId).SingleOrDefault();
        }
        public updateTrainingDTO trainingToUpdateTrainingDTO(int trainingId)
        {
            Training TR = new Training();
            TR = GetOneTraining(trainingId);

            updateTrainingDTO upT = new updateTrainingDTO();
            upT.trainingId = trainingId;
            upT.studentId = TR.studentId;
            upT.teamLeaderId = TR.teamLeaderId;
            upT.supervisorId = TR.supervisorId;
            upT.startDate = TR.startDate;
            upT.endDate = TR.endDate;
          
            upT.objectiveIDs = new List<int>();
            
            foreach (var t in TR.trainingObjectives)
            {
                upT.objectiveIDs.Add(t.objectiveId) ;
            }

            return upT;
        }
        public void EditTrainingRecord(updateTrainingDTO updateTrainingDTO)
        {
           Training training = context.trainings.Where(T => T.TrainingId == updateTrainingDTO.trainingId).SingleOrDefault();
            if (training != null)
            {
                training.studentId = updateTrainingDTO.studentId;
                training.supervisorId =updateTrainingDTO.supervisorId;
                training.teamLeaderId =updateTrainingDTO.teamLeaderId;
                training.startDate = updateTrainingDTO.startDate;
                training.endDate = updateTrainingDTO.endDate;
                context.SaveChanges();
                var trainingObjectivesOld = context.trainingObjectives.Where(T => T.trainingId == updateTrainingDTO.trainingId).ToList();
                foreach(var t in trainingObjectivesOld)
                {
                    context.trainingObjectives.Remove(t);
                }
                context.SaveChanges();
                foreach (var OID in updateTrainingDTO.objectiveIDs)
                {
                    TrainingObjectives trainingObjectives = new TrainingObjectives();
                    trainingObjectives.objectiveId = OID;
                    trainingObjectives.trainingId = training.TrainingId;
                    context.trainingObjectives.Add(trainingObjectives);
                }
                context.SaveChanges();
            }
        }
        public void deleteTraining(int TrainingId)
        {
            Training TR = GetOneTraining(TrainingId);
            var trainingObjectivesOld = context.trainingObjectives.Where(T => T.trainingId == TrainingId).ToList();
            foreach (var t in trainingObjectivesOld)
            {
                context.trainingObjectives.Remove(t);
            }
            context.SaveChanges();
            context.trainings.Remove(TR);
            context.SaveChanges();
        }
        public List<Training> GetTeamLeaderTrainings( string ID)
        {  
          
          var xx=  context.trainings.Include(x => x.supervisor)
                .Include(x => x.student)
                .ThenInclude(x => x.University).Include(x =>x.assignments)
                .Where(x => x.teamLeaderId== ID).ToList();
            return xx;
              
        }
        public List<Training> GetSupervisorTrainings(string ID)
        {

            var xx = context.trainings.Include(x => x.teamLeader)
                .ThenInclude(x =>x.Company)
                  .Include(x => x.student)
                  .ThenInclude(x => x.University).Include(x => x.assignments).Include(x => x.trainingObjectives).ThenInclude(x => x.objective)
                  .Where(x => x.supervisorId == ID).ToList();
            return xx;

        }
        public Training GetStudentTraining (string ID)
        {
            return context.trainings.Include(x => x.teamLeader).ThenInclude(x => x.Company)
                .Include(x => x.student)
                .Include(x => x.supervisor)
                .Include(x => x.trainingObjectives).ThenInclude(x => x.objective)

                .Where(x => x.studentId == ID).SingleOrDefault();
        }
        public int countTraining(string TeamLeaderId)
        {
            return context.trainings.Where(x => x.teamLeaderId ==  TeamLeaderId).Count();
        }
        public int countFinishedTraining(string TeamLeaderId)
        {
            DateTime currentDate = DateTime.Now;
            return context.trainings.Where(x => x.teamLeaderId == TeamLeaderId && x.endDate<currentDate).Count();
        }
        public int countCurrentTraining(string TeamLeaderId)
        {
            DateTime currentDate = DateTime.Now;
            return context.trainings.Where(x => x.teamLeaderId == TeamLeaderId && x.startDate < currentDate && x.endDate > currentDate).Count();
        }
       
       
    }
}
