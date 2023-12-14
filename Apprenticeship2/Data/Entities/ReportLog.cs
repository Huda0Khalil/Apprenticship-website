namespace Apprenticeship2.Data.Entities
{
    public class ReportLog
    {
        public int reportLogId { get; set; }
        public Report report {  get; set; }
        public int reportId { get; set; }
        public string reportName { get; set; }
        public string reportDescription { get; set; }
        public string reportNotes { get; set; }
        public ReportStatus reportStatus { get; set; }
        public int reportStatusId { get; set; }
        public DateTime logDate { get; set; }
        public List<ReportFiles>? reportFiles { get; set; }
       



    }
}
