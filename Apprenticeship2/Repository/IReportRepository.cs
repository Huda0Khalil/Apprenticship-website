using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public interface IReportRepository
    {
        public List<Report> GetAssignmentReports(int AssignmentID);
        public void createReport(InserReportDTO report);
        public Report GetReport(int ReportID);
        public void updateReportRecord(UpdateReportDTO report);
        public void deleteReport(int ReportID);
        public List<ReportStatus> reportStatuses();
        public void changeReportStatusFun(Report rep);
        public UpdateReportDTO ReporToUpdateReportDTO(Report rep);
    }
}
