namespace Apprenticeship2.Data.Entities
{
    public class ReportStatus
    {
        public int reportStatusId { get; set; }
        public string statusName { get; set; }
        public List<Report> reports { get; set; }
        public ReportLog reportLog { get; set; }
       

    }
}
