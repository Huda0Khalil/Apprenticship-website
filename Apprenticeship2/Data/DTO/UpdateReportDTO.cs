namespace Apprenticeship2.Data.DTO
{
    public class UpdateReportDTO
    {
        public int reportID { get; set; }
        public string reportName { get; set; }
        public string reportDescription { get; set; }
        public string reportNotes { get; set; }

        public int assignmentId { get; set; }
        public int reportStatusId { get; set; }
        public List<IFormFile> upFiles { get; set; }
    }
}
