using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public interface IReportLogRepository
    {
        public int AddToReportLog(Report repo);
        public IEnumerable<ReportLog> GetAllReportLogs(int assignmentId);

    }
}
