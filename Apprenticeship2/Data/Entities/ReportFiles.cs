namespace Apprenticeship2.Data.Entities
{
    public class ReportFiles
    {
        public int reportFilesId { get; set; }
        public string name { get; set; }
        public string contentType { get; set; }
        public byte[] file { get; set; }
        public Report report { get; set; }
        public int reportId { get; set; }
        public ReportLog? reportLog { get; set; }
        public int? reportLogId { get; set; }
    }
}
