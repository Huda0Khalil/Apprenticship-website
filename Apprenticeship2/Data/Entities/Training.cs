namespace Apprenticeship2.Data.Entities
{
    public class Training
    {
        public int TrainingId { get; set; }
        public Student student { get; set; }
        public string studentId { get; set; }
        public UniversitySupervisor supervisor { get; set; }
        public string supervisorId { get; set; }
        public TeamLeader teamLeader { get; set; }
        public string teamLeaderId { get; set; }
        public DateTime startDate {  get; set; }
        public DateTime endDate { get; set; }
        public List<Assignment> assignments { get; set; }
        public List<TrainingObjectives> trainingObjectives { get; set; }

    }
}
