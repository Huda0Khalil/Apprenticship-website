using Apprenticeship2.Data;
using Apprenticeship2.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship2.Repository
{
    public class ObjectiveRepository : IObjectiveRepository
    {
        ApplicationDbContext context;
        public ObjectiveRepository(ApplicationDbContext context) { 
            this.context = context;
        }
        public List<Objective> GetAllObjectives()
        {
            return context.objectives.ToList();
        }
        public List<TrainingObjectives> GetAllTrainingObjectives(int trainingId) { 
            return context.trainingObjectives.Include(x=>x.objective).Where(x => x.trainingId == trainingId).ToList();
        }

        
    }
}
