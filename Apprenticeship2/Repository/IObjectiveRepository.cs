using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public interface IObjectiveRepository
    {
        public List<Objective> GetAllObjectives();
        public List<TrainingObjectives> GetAllTrainingObjectives(int trainingId);

        }
    }
