namespace Apprenticeship2.Data.DTO
{
    public class updateTrainingDTO
    {
        public int trainingId {  get; set; }
        public string studentId { get; set; }
        public string supervisorId { get; set; }
        public string teamLeaderId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<int> objectiveIDs { get; set; }
    }
}
