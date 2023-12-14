using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public interface ITrainingRepository
    {
        public void createTraining(InsertTrainingDTO trainingDTO);
        public List<Training> GetAllTraining();
        public Training GetOneTraining(int trainingId);
        public updateTrainingDTO trainingToUpdateTrainingDTO(int trainingId);
        public void EditTrainingRecord(updateTrainingDTO updateTrainingDTO);
        public void deleteTraining(int TrainingId);
        public List<Training> GetTeamLeaderTrainings(string ID);
        public List<Training> GetSupervisorTrainings(string ID);
        public int countTraining(string TeamLeaderId);
        public int countFinishedTraining(string TeamLeaderId);
        public int countCurrentTraining(string TeamLeaderId);
       
        public Training GetStudentTraining(string ID);
    }
}

