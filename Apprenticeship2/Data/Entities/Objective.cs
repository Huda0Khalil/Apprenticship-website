namespace Apprenticeship2.Data.Entities
{
    public class Objective
    {
        public int objectiveId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ObjectivesSkills> objectivesskills { get; set; }
        public List<TrainingObjectives> trainingObjectsives { get; set; }
        public List<AssignmentObjectives> assignmentObjectives { get; set; }


    }
}
