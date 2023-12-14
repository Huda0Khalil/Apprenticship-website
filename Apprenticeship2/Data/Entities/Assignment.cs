namespace Apprenticeship2.Data.Entities
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string assignmentTitle { get; set; }
        public string AssignmentDescription { get; set; }
        public string assignmentNotes {  get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Training training { get; set; }
        public int trainingId { get; set; }
        public List<Report> reports { get; set; }
        public List<AssignmentObjectives> assignmentObjectives { get; set; }
        public List<AssignmentFiles>? fileAttatchments { get; set; }
        //public int? fileAttatchmentId { get; set; }


    }
}
